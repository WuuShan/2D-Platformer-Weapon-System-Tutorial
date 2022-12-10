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
        /// <summary>
        /// 武器
        /// </summary>
        protected Weapon weapon;

        // TODO: Fix this when finishing weapon data
        // protected AnimationEventHandler EventHandler => weapon.EventHandler;
        /// <summary>
        /// 用于处理动画事件
        /// </summary>
        protected AnimationEventHandler eventHandler;
        /// <summary>
        /// 核心组件管理器
        /// </summary>
        protected Core Core => weapon.Core;

        /// <summary>
        /// 攻击是否激活
        /// </summary>
        protected bool isAttackActive;

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

        protected virtual void OnEnable()
        {
            weapon.OnEnter += HandleEnter;
            weapon.OnExit += HandleExit;
        }

        protected virtual void OnDisable()
        {
            weapon.OnEnter -= HandleEnter;
            weapon.OnExit -= HandleExit;
        }
    }
}
