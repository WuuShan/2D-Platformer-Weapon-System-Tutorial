using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Bardent.CoreSystem
{
    /// <summary>
    /// 用来管理各种核心组件
    /// </summary>
    public class Core : MonoBehaviour
    {
        /// <summary>
        /// 存储所有核心组件
        /// </summary>
        private readonly List<CoreComponent> CoreComponents = new List<CoreComponent>();

        private void Awake()
        {
            // Find all core component children
            // 查找所有核心组件子组件
            var comps = GetComponentsInChildren<CoreComponent>();

            // Add componets found to list. Use old function to avoid duplicates.
            // 将找到的组件添加到列表中。使用旧功能避免重复。
            foreach (var component in comps)
            {
                AddComponent(component);
            }

            // Call Init on each
            // 调用每个Init
            foreach (var component in CoreComponents)
            {
                component.Init(this);
            }
        }

        /// <summary>
        /// 用于逻辑更新，遍历所有的核心组件并执行逻辑更新
        /// </summary>
        public void LogicUpdate()
        {
            foreach (CoreComponent component in CoreComponents)
            {
                component.LogicUpdate();
            }
        }

        /// <summary>
        /// 将核心组件添加到列表
        /// </summary>
        /// <param name="component">核心组件</param>
        public void AddComponent(CoreComponent component)
        {
            if (!CoreComponents.Contains(component))    // 判断列表是否有该核心组件
            {
                CoreComponents.Add(component);
            }
        }

        /// <summary>
        /// 根据组件类型获得核心组件
        /// </summary>
        /// <typeparam name="T">组件类型</typeparam>
        /// <returns>如果有返回组件，没有返回null</returns>
        public T GetCoreComponent<T>() where T : CoreComponent
        {
            var comp = CoreComponents.OfType<T>().FirstOrDefault();    // 返回 T 类型集合中的第一个组件，若是长度为 0 则返回 null

            if (comp == null)
            {
                Debug.LogWarning($"{typeof(T)} not found on {transform.parent.name}");
            }

            return comp;
        }

        /// <summary>
        /// 根据给定的组件类型，获取该类型的核心组件并将其赋值给给定的组件变量。
        /// </summary>
        /// <typeparam name="T">组件类型，要求该类型必须继承自CoreComponent</typeparam>
        /// <param name="value">组件变量，获取到的核心组件会被赋值给该变量。</param>
        /// <returns>返回获取到的核心组件</returns>
        public T GetCoreComponent<T>(ref T value) where T : CoreComponent
        {
            value = GetCoreComponent<T>();
            return value;
        }
    }
}