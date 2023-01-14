using System;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击动作判定框
    /// </summary>
    [Serializable]
    public class AttackActionHitBox : AttackData
    {
        /// <summary>
        /// 是否进行调试
        /// </summary>
        public bool Debug;

        /// <summary>
        /// 判定框的信息
        /// </summary>
        [field: SerializeField] public Rect HitBox { get; private set; }
    }
}