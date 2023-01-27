using UnityEngine;

/// <summary>
/// 击退接口，实现这个接口的对象可以被击退
/// </summary>
public interface IKnockBackable
{
    /// <summary>
    /// 往一个方向击退
    /// </summary>
    /// <param name="angle">击退的角度</param>
    /// <param name="strength">击退的力度</param>
    /// <param name="direction">击退的方向，1为正方向，-1为反方向</param>
    void KnockBack(Vector2 angle, float strength, int direction);
}
