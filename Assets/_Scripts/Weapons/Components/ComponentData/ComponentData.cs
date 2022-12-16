using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 组件数据
    /// </summary>
    [Serializable]
    public class ComponentData
    {

    }

    /// <summary>
    /// 组件数据
    /// </summary>
    /// <typeparam name="T">攻击相关的数据</typeparam>
    public class ComponentData<T> : ComponentData where T : AttackData
    {
        /// <summary>
        /// 攻击数据
        /// </summary>
        [field: SerializeField] public T[] AttackData { get; private set; }
    }
}
