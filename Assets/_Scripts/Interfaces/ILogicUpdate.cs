/// <summary>
/// 用于逻辑更新的接口
/// </summary>
public interface ILogicUpdate
{
    /// <summary>
    /// 游戏逻辑更新函数，在每一帧被调用
    /// </summary>
    void LogicUpdate();
}