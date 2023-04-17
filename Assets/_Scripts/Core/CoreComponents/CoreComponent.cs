using Bardent.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.CoreSystem
{
    /// <summary>
    /// 核心组件基类，此类提供一个基础的组件结构，其他组件继承此类。
    /// </summary>
    public class CoreComponent : MonoBehaviour, ILogicUpdate
    {
        /// <summary>
        /// 游戏对象上的核心
        /// </summary>
        protected Core core;

        /// <summary>
        /// 初始化核心组件
        /// </summary>
        /// <param name="core">核心组件</param>
        public virtual void Init(Core core)
        {
            this.core = core;
        }

        protected virtual void Awake()
        {
            // 获取父物体上的核心组件
            core = transform.parent.GetComponent<Core>();

            if (core == null)
            {
                Debug.LogError("There is no Core on the parent");
            }

            // 添加组件到核心组件中
            core.AddComponent(this);
        }

        public virtual void LogicUpdate() { }
    }
}