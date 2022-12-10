using Bardent.Weapons.Components.ComponentData;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Bardent.Weapons
{
    /// <summary>
    /// 武器数据SO
    /// </summary>
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class WeaponDataSO : ScriptableObject
    {
        /// <summary>
        /// 攻击段数
        /// </summary>
        [field: SerializeField] public int NumberOfAttacks { get; private set; }

        /// <summary>
        /// 组件数据列表
        /// </summary>
        [field: SerializeReference] public List<ComponentData> ComponentData { get; private set; }

        /// <summary>
        /// 获得组件数据列表中指定的数据类型
        /// </summary>
        /// <typeparam name="T">组件数据的类型</typeparam>
        /// <returns>组件数据列表中第一个指定类型的数据；如果未找到该类型的数据，则返回null</returns>
        public T GetData<T>()
        {
            // 使用LINQ的OfType方法，获取所有指定类型的数据
            // 然后使用FirstOrDefault方法，返回第一个指定类型的数据
            return ComponentData.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// 添加一个武器精灵数据到组件数据列表
        /// </summary>
        [ContextMenu("Add Sprite Data")]
        private void AddSpriteData() => ComponentData.Add(new WeaponSpriteData());

        /// <summary>
        /// 添加一个武器移动数据到组件数据列表
        /// </summary>
        [ContextMenu("Add Movement Data")]
        private void AddMovementData() => ComponentData.Add(new MovementData());
    }
}
