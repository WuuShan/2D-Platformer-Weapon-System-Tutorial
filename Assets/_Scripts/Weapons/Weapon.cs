using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bardent.Utilities;

namespace Bardent.Weapons
{
    /// <summary>
    /// 武器
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        /// <summary>
        /// 攻击段数
        /// </summary>
        [SerializeField] private int numberOfAttacks;
        /// <summary>
        /// 重置攻击计数器的冷却时间
        /// </summary>
        [SerializeField] private float attackCounterResetCooldown;

        /// <summary>
        /// 当前武器攻击计数器
        /// </summary>
        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= numberOfAttacks ? 0 : value;
        }

        /// <summary>
        /// 武器完成攻击事件
        /// </summary>
        public event Action OnExit;

        /// <summary>
        /// 玩家攻击动画机
        /// </summary>
        private Animator anim;
        /// <summary>
        /// 用于显示玩家攻击动画的物体
        /// </summary>
        private GameObject baseGameObject;

        /// <summary>
        /// 动画事件处理
        /// </summary>
        private AnimationEventHandler eventHandler;

        /// <summary>
        /// 当前攻击计数器
        /// </summary>
        private int currentAttackCounter;

        /// <summary>
        /// 负责重置攻击计数器的计时器
        /// </summary>
        private Timer attackCounterResetTimer;

        /// <summary>
        /// 使用武器攻击时，执行一次
        /// </summary>
        public void Enter()
        {
            print($"{transform.name} enter");

            attackCounterResetTimer.StopTimer();

            anim.SetBool("active", true);
            anim.SetInteger("counter", CurrentAttackCounter);
        }

        /// <summary>
        /// 广播武器完成攻击事件
        /// </summary>
        private void Exit()
        {
            anim.SetBool("active", false);

            CurrentAttackCounter++;
            attackCounterResetTimer.StartTimer();

            OnExit?.Invoke();
        }

        private void Awake()
        {
            baseGameObject = transform.Find("Base").gameObject;
            anim = baseGameObject.GetComponent<Animator>();

            eventHandler = baseGameObject.GetComponent<AnimationEventHandler>();

            attackCounterResetTimer = new Timer(attackCounterResetCooldown);
        }

        private void Update()
        {
            attackCounterResetTimer.Tick();
        }

        /// <summary>
        /// 重置攻击计数器
        /// </summary>
        private void ResetAttackCounter() => CurrentAttackCounter = 0;

        private void OnEnable()
        {
            // 订阅事件
            eventHandler.OnFinish += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable()
        {
            // 注销事件
            eventHandler.OnFinish -= Exit;
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
        }
    }
}

