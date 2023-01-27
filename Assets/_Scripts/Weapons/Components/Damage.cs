using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 处理伤害相关
    /// </summary>
    public class Damage : WeaponComponent<DamageData, AttackDamage>
    {
        /// <summary>
        /// 用于检测碰撞的组件
        /// </summary>
        private ActionHitBox hitBox;

        /// <summary>
        /// 处理检测到的碰撞体
        /// </summary>
        /// <param name="colliders">碰撞体数组</param>
        private void HandleDetectCollider2D(Collider2D[] colliders)
        {
            // 遍历碰撞体数组
            foreach (var item in colliders)
            {
                // 如果碰撞体上有IDamageable接口
                if (item.TryGetComponent(out IDamageable damageable))
                {
                    // 调用伤害方法
                    damageable.Damage(currentAttackData.Amount);
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();

            hitBox = GetComponent<ActionHitBox>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }
    }
}
