using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bardent.CoreSystem
{
    /// <summary>
    /// 接受伤害组件
    /// </summary>
    public class DamageReceiver : CoreComponent, IDamageable
    {
        /// <summary>
        /// 伤害粒子效果
        /// </summary>
        [SerializeField] private GameObject damageParticles;

        private CoreComp<Stats> stats;
        private CoreComp<ParticleManager> particleManager;

        public void Damage(float amount)
        {
            Debug.Log(core.transform.parent.name + " Damaged!");
            stats.Comp?.DecreaseHealth(amount);
            particleManager.Comp?.StartParticlesWithRandomRotation(damageParticles);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = new CoreComp<Stats>(core);
            particleManager = new CoreComp<ParticleManager>(core);
        }
    }
}
