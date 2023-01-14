using System.Collections;
using UnityEngine;

namespace Bardent.CoreSystem
{
    /// <summary>
    /// 方便调用玩家核心组件
    /// </summary>
    /// <typeparam name="T">对应的核心组件</typeparam>
    public class CoreComp<T> where T : CoreComponent
    {
        /// <summary>
        /// 核心
        /// </summary>
        private Core core;
        /// <summary>
        /// 核心组件
        /// </summary>
        private T comp;

        /// <summary>
        /// 核心组件
        /// </summary>
        public T Comp => comp ? comp : core.GetCoreComponent(ref comp);

        public CoreComp(Core core)
        {
            if (core == null)
            {
                Debug.LogWarning($"Core is Null for component {typeof(T)}");
            }

            this.core = core;
        }
    }
}