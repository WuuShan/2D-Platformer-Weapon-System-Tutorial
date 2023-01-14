using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 攻击动作判定框数据相关
    /// </summary>
    public class ActionHitBoxData : ComponentData<AttackActionHitBox>
    {
        /// <summary>
        /// 可检测的层级
        /// </summary>
        [field: SerializeField] public LayerMask DetectableLayers { get; private set; }
    }
}