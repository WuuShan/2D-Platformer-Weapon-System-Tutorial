using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击精灵集
    /// </summary>
    [Serializable]
    public class AttackSprites : AttackData
    {
        /// <summary>
        /// 各组攻击阶段的精灵集
        /// </summary>
        [field: SerializeField] public PhaseSprites[] PhaseSprites { get; private set; }
    }

    /// <summary>
    /// 每个攻击阶段的精灵集
    /// </summary>
    [Serializable]
    public struct PhaseSprites
    {
        /// <summary>
        /// 攻击阶段
        /// </summary>
        [field: SerializeField] public AttackPhases Phase { get; private set; }
        /// <summary>
        /// 精灵集
        /// </summary>
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
}
