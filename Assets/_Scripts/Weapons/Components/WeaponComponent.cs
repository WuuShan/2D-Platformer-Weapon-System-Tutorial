using Bardent.CoreSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 武器组件
    /// </summary>
    public abstract class WeaponComponent : MonoBehaviour
    {
        // TODO: Fix this when finishing weapon data
        // protected AnimationEventHandler EventHandler => weapon.EventHandler;
        /// <summary>
        /// 用于处理动画事件
        /// </summary>
        protected AnimationEventHandler eventHandler;

        /// <summary>
        /// 攻击是否激活
        /// </summary>
        protected bool isAttackActive;

        /// <summary>
        /// 武器
        /// </summary>
        protected Weapon weapon;

        /// <summary>
        /// 核心组件管理器
        /// </summary>
        protected Core Core => weapon.Core;

        public virtual void Init()
        { }

        protected virtual void Awake()
        {
            weapon = GetComponent<Weapon>();

            eventHandler = GetComponentInChildren<AnimationEventHandler>();
        }

        /// <summary>
        /// 武器开始攻击
        /// </summary>
        protected virtual void HandleEnter()
        {
            isAttackActive = true;
        }

        /// <summary>
        /// 武器完成攻击
        /// </summary>
        protected virtual void HandleExit()
        {
            isAttackActive = false;
        }

        protected virtual void OnDestroy()
        {
            weapon.OnEnter -= HandleEnter;
            weapon.OnExit -= HandleExit;
        }

        protected virtual void Start()
        {
            weapon.OnEnter += HandleEnter;
            weapon.OnExit += HandleExit;
        }
    }

    /// <summary>
    /// 武器组件
    /// </summary>
    /// <typeparam name="T1">武器组件相关的数据</typeparam>
    /// <typeparam name="T2">攻击相关的数据</typeparam>
    public abstract class WeaponComponent<T1, T2> : WeaponComponent where T1 : ComponentData<T2> where T2 : AttackData
    {
        /// <summary>
        /// 当前攻击数据
        /// </summary>
        protected T2 currentAttackData;

        /// <summary>
        /// 组件数据
        /// </summary>
        protected T1 data;

        public override void Init()
        {
            base.Init();

            data = weapon.Data.GetData<T1>();
        }

        protected override void HandleEnter()
        {
            base.HandleEnter();

            currentAttackData = data.AttackData[weapon.CurrentAttackCounter];
        }
    }
}