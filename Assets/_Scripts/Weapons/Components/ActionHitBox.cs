using Bardent.CoreSystem;
using System;
using System.Collections;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击动作判定框相关
    /// </summary>
    public class ActionHitBox : WeaponComponent<ActionHitBoxData, AttackActionHitBox>
    {
        /// <summary>
        /// 检测到的碰撞体事件
        /// </summary>
        public event Action<Collider2D[]> OnDetectedCollider2D;

        /// <summary>
        /// 玩家移动核心组件
        /// </summary>
        private CoreComp<CoreSystem.Movement> movement;

        /// <summary>
        /// 判定框偏移
        /// </summary>
        private Vector2 offset;

        /// <summary>
        /// 检测到的碰撞体
        /// </summary>
        private Collider2D[] detected;

        /// <summary>
        /// 处理攻击动作
        /// </summary>
        private void HandleAttackAction()
        {
            // 设置判定框的位置
            offset.Set(
                transform.position.x + (currentAttackData.HitBox.center.x * movement.Comp.FacingDirection),
                transform.position.y + currentAttackData.HitBox.center.y
                );

            // 获取判定框中所有在可检测层的碰撞体
            detected = Physics2D.OverlapBoxAll(offset, currentAttackData.HitBox.size, 0f, data.DetectableLayers);

            if (detected.Length == 0) return;

            // 广播检测到的碰撞体事件
            OnDetectedCollider2D?.Invoke(detected);
        }

        protected override void Start()
        {
            base.Start();

            movement = new CoreComp<CoreSystem.Movement>(Core);
            eventHandler.OnAttackAction += HandleAttackAction;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            eventHandler.OnAttackAction -= HandleAttackAction;
        }

        private void OnDrawGizmosSelected()
        {
            if (data == null) return;

            foreach (var item in data.AttackData)
            {
                if (!item.Debug) continue;

                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.position, item.HitBox.size);

                Gizmos.color = Color.white;
                Gizmos.DrawWireCube(transform.position + (Vector3)item.HitBox.center, item.HitBox.size);
            }
        }
    }
}