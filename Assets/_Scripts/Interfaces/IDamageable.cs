namespace Bardent.Interfaces
{
    /// <summary>
    /// 定义可以受到伤害的对象的行为。
    /// 此接口可以用于角色，敌人，建筑物等对象。
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// 减少对象的生命值。
        /// </summary>
        /// <param name="amount">伤害值</param>
        void Damage(float amount);
    }
}

