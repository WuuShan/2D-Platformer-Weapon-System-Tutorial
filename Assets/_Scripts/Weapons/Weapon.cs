using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bardent.Utilities;
using Bardent.CoreSystem;

namespace Bardent.Weapons
{
    /// <summary>
    /// 武器
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        public event Action<bool> OnCurrentInputChange;

        /// <summary>
        /// 重置攻击计数器的冷却时间
        /// </summary>
        [SerializeField] private float attackCounterResetCooldown;
        /// <summary>
        /// 武器数据
        /// </summary>
        public WeaponDataSO Data { get; private set; }

        /// <summary>
        /// 当前武器攻击计数器
        /// </summary>
        public int CurrentAttackCounter
        {
            get => currentAttackCounter;
            private set => currentAttackCounter = value >= Data.NumberOfAttacks ? 0 : value;
        }

        public bool CurrentInput
        {
            get => currentInput;
            set
            {
                if (currentInput != value)
                {
                    currentInput = value;
                    OnCurrentInputChange?.Invoke(currentInput);
                }
            }
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
        /// 玩家攻击动画器
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
        public AnimationEventHandler EventHandler { get; private set; }

        /// <summary>
        /// 用来管理各种核心组件
        /// </summary>
        public Core Core { get; private set; }

        /// <summary>
        /// 当前攻击计数器
        /// </summary>
        private int currentAttackCounter;

        /// <summary>
        /// 负责重置攻击计数器的计时器
        /// </summary>
        private Timer attackCounterResetTimer;

        private bool currentInput;

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
        /// 设置核心组件管理器
        /// </summary>
        /// <param name="core">核心</param>
        public void SetCore(Core core)
        {
            Core = core;
        }

        /// <summary>
        /// 设置武器数据
        /// </summary>
        /// <param name="data">数据</param>
        public void SetData(WeaponDataSO data)
        {
            Data = data;
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

            EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();

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
            EventHandler.OnFinish += Exit;
            attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
        }

        private void OnDisable()
        {
            // 注销事件
            EventHandler.OnFinish -= Exit;
            attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
        }
    }
}

