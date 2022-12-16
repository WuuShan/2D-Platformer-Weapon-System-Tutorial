using System;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击移动
    /// </summary>
    [Serializable]
    public class AttackMovement : AttackData
    {
        /// <summary>
        /// 移动方向
        /// </summary>
        [field: SerializeField] public Vector2 Direction { get; private set; }
        /// <summary>
        /// 移动速度
        /// </summary>
        [field: SerializeField] public float Velocity { get; private set; }
    }
}