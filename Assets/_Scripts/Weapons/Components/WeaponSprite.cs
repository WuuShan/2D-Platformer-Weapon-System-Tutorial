using Bardent.Weapons.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 武器精灵
    /// </summary>
    public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprites>
    {
        /// <summary>
        /// 玩家精灵渲染器
        /// </summary>
        private SpriteRenderer baseSpriteRenderer;
        /// <summary>
        /// 武器精灵渲染器
        /// </summary>
        private SpriteRenderer weaponSpriteRenderer;

        /// <summary>
        /// 当前武器精灵索引
        /// </summary>
        private int currentWeaponSpriteIndex;

        /// <summary>
        /// 当前攻击阶段的精灵集
        /// </summary>
        private Sprite[] currentPhaseSprites;

        /// <summary>
        /// 武器攻击处理
        /// </summary>
        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentWeaponSpriteIndex = 0;
        }

        /// <summary>
        /// 在动画开始播放时，会执行该攻击阶段处理函数
        /// </summary>
        /// <param name="phase">攻击阶段</param>
        private void HandleEnterAttackPhase(AttackPhases phase)
        {
            currentWeaponSpriteIndex = 0;

            // 获得当前攻击阶段要使用武器精灵集
            currentPhaseSprites = currentAttackData.PhaseSprites.FirstOrDefault(data => data.Phase == phase).Sprites;
        }

        /// <summary>
        /// 玩家精灵切换时，会调用此处理函数
        /// </summary>
        /// <param name="sr"></param>
        private void HandleBaseSpriteChange(SpriteRenderer sr)
        {
            // 玩家没有攻击时，清空武器精灵
            if (!isAttackActive)
            {
                weaponSpriteRenderer.sprite = null;
                return;
            }

            if (currentWeaponSpriteIndex >= currentPhaseSprites.Length)
            {
                Debug.LogWarning($"{weapon.name} 武器精灵长度不匹配");
            }

            // 根据当前武器精灵索引值，将切换武器精灵
            weaponSpriteRenderer.sprite = currentPhaseSprites[currentWeaponSpriteIndex];

            currentWeaponSpriteIndex++;
        }

        protected override void Start()
        {
            base.Start();

            baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
            weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();

            data = weapon.Data.GetData<WeaponSpriteData>();

            baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);

            eventHandler.OnEnterAttackPhases += HandleEnterAttackPhase;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);

            eventHandler.OnEnterAttackPhases -= HandleEnterAttackPhase;
        }
    }
}
