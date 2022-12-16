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
        /// 精灵集
        /// </summary>
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
}
