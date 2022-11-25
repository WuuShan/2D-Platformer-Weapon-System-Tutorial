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
        /// 武器数据
        /// </summary>
        [field:SerializeField]public WeaponDataSO Data { get; private set; }
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
            private set => currentAttackCounter = value >= Data.NumberOfAttacks ? 0 : value;
        }

        /// <summary>
        /// 武器开始攻击事件
        /// </summary>
        public event Action OnEnter;
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
        public GameObject BaseGameObject { get; private set; }
        /// <summary>
        /// 用于显示武器攻击动画的物体
        /// </summary>
        public GameObject WeaponSpriteGameObject { get; private set; }

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

            OnEnter?.Invoke();
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
            BaseGameObject = transform.Find("Base").gameObject;
            WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;

            anim = BaseGameObject.GetComponent<Animator>();

            eventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();

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

