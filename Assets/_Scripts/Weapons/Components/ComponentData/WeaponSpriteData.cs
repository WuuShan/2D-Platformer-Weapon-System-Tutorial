using Bardent.Weapons.Components;
using Bardent.Weapons.Components.ComponentData.AttackData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components.ComponentData
{
    /// <summary>
    /// 武器精灵数据
    /// </summary>
    public class WeaponSpriteData :ComponentData
    {
        /// <summary>
        /// 攻击精灵集数据
        /// </summary>
        [field:SerializeField]public AttackSprites[] AttackData { get; private set; }
    }
}
