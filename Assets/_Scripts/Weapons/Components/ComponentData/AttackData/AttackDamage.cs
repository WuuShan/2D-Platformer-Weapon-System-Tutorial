using System;
using System.Collections;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击伤害类
    /// </summary>
    [Serializable]
    public class AttackDamage : AttackData
    {
        /// <summary>
        /// 伤害量
        /// </summary>
        [field: SerializeField] public float Amount { get; private set; }

    }
}