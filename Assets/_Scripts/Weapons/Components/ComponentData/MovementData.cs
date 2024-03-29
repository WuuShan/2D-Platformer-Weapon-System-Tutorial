﻿using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 移动数据
    /// </summary>
    public class MovementData : ComponentData<AttackMovement>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(Movement);
        }
    }
}