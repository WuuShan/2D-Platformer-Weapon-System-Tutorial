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
        /// 广播动画结束后触发的事件
        /// </summary>
        private void AnimationFinishedTrigger() => OnFinish?.Invoke();


    }
}
