using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons
{
    /// <summary>
    /// 动画事件处理程序（异步消息的处理）
    /// </summary>
    public class AnimationEventHandler : MonoBehaviour
    {
        /// <summary>
        /// 动画结束后触发的事件
        /// </summary>
        public event Action OnFinish;
        /// <summary>
        /// 在角色开始攻击移动时触发的事件
        /// </summary>
        public event Action OnStartMovement;
        /// <summary>
        /// 在角色停止攻击移动时触发的事件
        /// </summary>
        public event Action OnStopMovement;
        /// <summary>
        /// 在角色执行攻击动作时触发的事件
        /// </summary>
        public event Action OnAttackAction;
        public event Action OnMinHoldPassed;

        public event Action<AttackPhases> OnEnterAttackPhases;

        /// <summary>
        /// 广播动画结束后触发的事件
        /// </summary>
        private void AnimationFinishedTrigger() => OnFinish?.Invoke();
        /// <summary>
        /// 广播角色开始攻击移动时触发的事件
        /// </summary>
        private void StartMovementTrigger() => OnStartMovement?.Invoke();
        /// <summary>
        /// 广播角色停止攻击移动时触发的事件
        /// </summary>
        private void StopMovementTrigger() => OnStopMovement?.Invoke();
        /// <summary>
        /// 广播角色执行攻击动作时触发的事件
        /// </summary>
        private void AttackActionTrigger() => OnAttackAction?.Invoke();

        private void MinHoldPassedTrigger() => OnMinHoldPassed?.Invoke();

        private void EnterAttackPhases(AttackPhases phase) => OnEnterAttackPhases?.Invoke(phase);
    }
}
