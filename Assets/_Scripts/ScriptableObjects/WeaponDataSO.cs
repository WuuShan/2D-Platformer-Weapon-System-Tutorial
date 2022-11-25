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
    [CreateAssetMenu(fileName ="newWeaponData",menuName ="Data/Weapon Data/Basic Weapon Data",order =0)]
    public class WeaponDataSO : ScriptableObject
    {
        /// <summary>
        /// 攻击段数
        /// </summary>
        [field:SerializeField] public int NumberOfAttacks { get; private set; }

        /// <summary>
        /// 组件数据列表
        /// </summary>
        [field:SerializeReference]public List<ComponentData> componentData { get; private set; }

        /// <summary>
        /// 获得组件数据列表中指定的数据类型
        /// </summary>
        /// <typeparam name="T">组件数据</typeparam>
        /// <returns></returns>
        public T GetData<T>()
        {
            // OfType<T>() 根据指定类型筛选 IEnumerable 的元素。
            // FirstOrDefault() 返回序列中的第一个元素；如果未找到该元素，则返回默认值。
            return componentData.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        /// 添加一个武器精灵数据到组件数据列表
        /// </summary>
        [ContextMenu("Add Sprite Data")]
        private void AddSpriteData() => componentData.Add(new WeaponSpriteData());
    }
}
