using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 控制角色移动的武器移动组件
    /// </summary>
    public class Movement : WeaponComponent<MovementData, AttackMovement>
    {
        /// <summary>
        /// 玩家的核心移动组件
        /// </summary>
        private CoreSystem.Movement coreMovement;

        /// <summary>
        /// 获取玩家的核心移动组件
        /// </summary>
        private CoreSystem.Movement CoreMovement => coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);

        /// <summary>
        /// 处理角色开始攻击移动的事件
        /// </summary>
        private void HandleStartMovement()
        {
            // 获取当前攻击的攻击移动数据
            var currentAttackData = data.AttackData[weapon.CurrentAttackCounter];

            // 设置角色的速度和方向，使角色攻击移动
            CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);
        }

        /// <summary>
        /// 处理角色停止攻击移动的事件
        /// </summary>
        private void HandleStopMovement()
        {
            // 设置角色的速度为零，使角色停止攻击移动
            CoreMovement.SetVelocityZero();
        }

        protected override void Start()
        {
            base.Start();

            // 注册攻击移动事件处理函数
            eventHandler.OnStartMovement += HandleStartMovement;
            eventHandler.OnStopMovement += HandleStopMovement;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            // 注消攻击移动事件处理函数
            eventHandler.OnStartMovement -= HandleStartMovement;
            eventHandler.OnStopMovement -= HandleStopMovement;
        }
    }
}
