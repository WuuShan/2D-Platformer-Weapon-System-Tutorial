using Bardent.Weapons.Components;
using System;
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
        /// 动画控制器
        /// </summary>
        [field: SerializeField] public RuntimeAnimatorController AnimatorController { get; private set; }

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
        /// 获得武器挂载的所有依赖组件
        /// </summary>
        /// <returns></returns>
        public List<Type> GetAllDependencies()
        {
            return ComponentData.Select(component => component.ComponentDependency).ToList();
        }

        /// <summary>
        /// 添加一个组件数据到列表
        /// </summary>
        /// <param name="data">组件数据</param>
        public void AddData(ComponentData data)
        {
            // 将组件数据列表与组件数据进行类型比较 如果相等则有重复组件数据 跳出
            if (ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null) return;

            ComponentData.Add(data);
        }
    }
}