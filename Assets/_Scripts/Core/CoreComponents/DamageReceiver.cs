using Bardent.Interfaces;
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

        private Stats stats;
        private ParticleManager particleManager;

        public void Damage(float amount)
        {
            Debug.Log(core.transform.parent.name + " Damaged!");
            stats.Health.Decrease(amount);
            particleManager.StartParticlesWithRandomRotation(damageParticles);
        }

        protected override void Awake()
        {
            base.Awake();

            stats = core.GetCoreComponent<Stats>();
            particleManager = core.GetCoreComponent<ParticleManager>();
        }
    }
}
