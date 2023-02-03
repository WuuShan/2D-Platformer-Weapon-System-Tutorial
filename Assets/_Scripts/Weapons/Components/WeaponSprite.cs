using Bardent.Weapons.Components;
using System;
using System.Collections;
using System.Collections.Generic;
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
        /// 武器攻击处理
        /// </summary>
        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentWeaponSpriteIndex = 0;
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

            // 获得当前攻击要使用武器精灵集
            var currentAttackSprites = currentAttackData.Sprites;

            if (currentWeaponSpriteIndex >= currentAttackSprites.Length)
            {
                Debug.LogWarning($"{weapon.name} weapon sprites length mismatch");
            }

            // 根据当前武器精灵索引值，将切换武器精灵
            weaponSpriteRenderer.sprite = currentAttackSprites[currentWeaponSpriteIndex];

            currentWeaponSpriteIndex++;
        }

        protected override void Start()
        {
            base.Start();

            baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
            weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();

            data = weapon.Data.GetData<WeaponSpriteData>();

            baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);
        }
    }
}
