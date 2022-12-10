using Bardent.Weapons.Components.ComponentData.AttackData;
using UnityEngine;

namespace Bardent.Weapons.Components.ComponentData
{
    /// <summary>
    /// 移动数据
    /// </summary>
    public class MovementData : ComponentData
    {
        /// <summary>
        /// 攻击移动数据
        /// </summary>
        [field: SerializeField] public AttackMovement[] AttackData { get; private set; }

    }
}