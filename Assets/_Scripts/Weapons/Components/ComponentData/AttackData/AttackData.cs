using System.Collections;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击数据
    /// </summary>
    public class AttackData
    {
        [SerializeField, HideInInspector] private string name;

        public void SetAttackName(int i) => name = $"Attack {i}";
    }
}