using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.Weapons.Components
{
    /// <summary>
    /// 击退组件数据
    /// </summary>
    public class KnockBackData : ComponentData<AttackKnockBack>
    {
        protected override void SetComponentDependency()
        {
            ComponentDependency = typeof(KnockBack);
        }
    }
}
