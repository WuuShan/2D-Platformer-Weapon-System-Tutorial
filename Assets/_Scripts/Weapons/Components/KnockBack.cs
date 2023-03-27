using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 武器的击退组件
    /// </summary>
    public class KnockBack : WeaponComponent<KnockBackData, AttackKnockBack>
    {
        /// <summary>
        /// 武器命中框
        /// </summary>
        private ActionHitBox hitBox;

        /// <summary>
        /// 刚体移动组件
        /// </summary>
        private CoreSystem.Movement movement;

        /// <summary>
        /// 处理检测到的2D碰撞体
        /// </summary>
        /// <param name="colliders">2D碰撞体</param>
        private void HandleDetectCollider2D(Collider2D[] colliders)
        {
            foreach (var item in colliders)
            {
                if (item.TryGetComponent(out IKnockBackable knockBackable))
                {
                    knockBackable.KnockBack(currentAttackData.Angle, currentAttackData.Strength, movement.FacingDirection);
                }
            }
        }

        protected override void Start()
        {
            base.Start();

            hitBox = GetComponent<ActionHitBox>();

            hitBox.OnDetectedCollider2D += HandleDetectCollider2D;

            movement = Core.GetCoreComponent<CoreSystem.Movement>();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
        }
    }
}
