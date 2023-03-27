using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击数据的击退数据
    /// </summary>
    [Serializable]
    public class AttackKnockBack : AttackData
    {
        /// <summary>
        /// 击退角度
        /// </summary>
        [field: SerializeField] public Vector2 Angle { get; private set; }
        /// <summary>
        /// 击退力度
        /// </summary>
        [field: SerializeField] public float Strength { get; private set; }
    }
}
