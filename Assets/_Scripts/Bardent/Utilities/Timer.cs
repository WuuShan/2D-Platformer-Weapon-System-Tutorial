using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Utilities
{
    /// <summary>
    /// 计时器
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// 计时完成后触发的事件
        /// </summary>
        public event Action OnTimerDone;

        /// <summary>
        /// 开始时间
        /// </summary>
        private float startTime;
        /// <summary>
        /// 持续时间
        /// </summary>
        private float duration;
        /// <summary>
        /// 目标时间
        /// </summary>
        private float targetTime;

        /// <summary>
        /// 计时器是否激活
        /// </summary>
        private bool isActive;

        /// <summary>
        /// 设置计数器
        /// </summary>
        /// <param name="duration">要计时的时长</param>
        public Timer(float duration)
        {
            this.duration = duration;
        }

        /// <summary>
        /// 初始化计时器
        /// </summary>
        public void StartTimer()
        {
            startTime = Time.time;
            targetTime = startTime + duration;
            isActive = true;
        }

        /// <summary>
        /// 停止计时器
        /// </summary>
        public void StopTimer()
        {
            isActive = false;
        }

        /// <summary>
        /// 计时中
        /// </summary>
        public void Tick()
        {
            if (!isActive) return;

            if (Time.time >= targetTime)
            {
                OnTimerDone?.Invoke();
                StopTimer();
            }
        }
    }
}
