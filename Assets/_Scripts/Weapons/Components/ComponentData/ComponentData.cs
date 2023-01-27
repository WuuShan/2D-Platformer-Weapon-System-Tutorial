using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 与武器组件相关的数据
    /// </summary>
    [Serializable]
    public class ComponentData
    {
        [SerializeField, HideInInspector] private string name;

        public ComponentData()
        {
            SetComponentNmae();
        }

        public void SetComponentNmae() => name = GetType().Name;

        /// <summary>
        /// 设置攻击数据的名称
        /// </summary>
        public virtual void SetAttackDataNames() { }

        /// <summary>
        /// 初始化攻击数据
        /// </summary>
        /// <param name="numberOfAttacks">攻击数量</param>
        public virtual void InitializeAttackData(int numberOfAttacks) { }
    }

    /// <summary>
    /// 与武器组件相关的数据
    /// </summary>
    /// <typeparam name="T">攻击相关的数据</typeparam>
    [Serializable]
    public class ComponentData<T> : ComponentData where T : AttackData
    {
        [SerializeField] private T[] attackData;

        /// <summary>
        /// 攻击数据
        /// </summary>
        public T[] AttackData { get => attackData; private set => attackData = value; }

        public override void SetAttackDataNames()
        {
            base.SetAttackDataNames();

            for (int i = 0; i < AttackData.Length; i++)
            {
                AttackData[i].SetAttackName(i + 1);
            }
        }

        public override void InitializeAttackData(int numberOfAttacks)
        {
            base.InitializeAttackData(numberOfAttacks);

            int oldLen = attackData != null ? attackData.Length : 0;

            if (oldLen == numberOfAttacks) return;

            Array.Resize(ref attackData, numberOfAttacks);

            if (oldLen < numberOfAttacks)
            {
                for (int i = oldLen; i < numberOfAttacks; i++)
                {
                    var newObj = Activator.CreateInstance(typeof(T)) as T;
                    attackData[i] = newObj;
                }
            }

            SetAttackDataNames();
        }
    }
}
