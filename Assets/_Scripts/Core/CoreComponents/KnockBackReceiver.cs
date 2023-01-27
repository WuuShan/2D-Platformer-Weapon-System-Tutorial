using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.CoreSystem
{
    /// <summary>
    /// 用来处理击退相关的逻辑。
    /// </summary>
    public class KnockBackReceiver : CoreComponent, IKnockBackable
    {
        /// <summary>
        /// 最大击退时间
        /// </summary>
        [SerializeField] private float maxKnockBackTime = 0.2f;

        /// <summary>
        /// 是否激活击退
        /// </summary>
        private bool isKnockBackActive;
        /// <summary>
        /// 击退开始时间
        /// </summary>
        private float knockBackStartTime;

        private CoreComp<Movement> movement;
        private CoreComp<CollisionSenses> collisionSenses;

        public override void LogicUpdate()
        {
            CheckKnockBack();
        }

        public void KnockBack(Vector2 angle, float strength, int direction)
        {
            movement.Comp?.SetVelocity(strength, angle, direction);
            movement.Comp.CanSetVelocity = false;

            isKnockBackActive = true;
            knockBackStartTime = Time.time;
        }

        /// <summary>
        /// 检查当前是否激活击退
        /// </summary>
        private void CheckKnockBack()
        {
            if (isKnockBackActive && ((movement.Comp?.CurrentVelocity.y <= 0.01f && collisionSenses.Comp.Ground)
                || Time.time >= knockBackStartTime + maxKnockBackTime))
            {
                isKnockBackActive = false;
                movement.Comp.CanSetVelocity = true;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            movement = new CoreComp<Movement>(core);
            collisionSenses = new CoreComp<CollisionSenses>(core);
        }
    }
}