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

        /// <summary>
        /// 攻击是否激活
        /// </summary>
        protected bool isAttackActive;

        protected virtual void Awake()
        {
            weapon = GetComponent<Weapon>();
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
