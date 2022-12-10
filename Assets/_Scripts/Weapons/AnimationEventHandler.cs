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

    }
}
