using System.Collections;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 与攻击相关的数据
    /// </summary>
    public class AttackData
    {
        /// <summary>
        /// 攻击名称，编辑器中隐藏
        /// </summary>
        [SerializeField, HideInInspector] private string name;

        /// <summary>
        /// 设置攻击名称
        /// </summary>
        /// <param name="i">攻击编号</param>
        public void SetAttackName(int i) => name = $"Attack {i}";
    }
}