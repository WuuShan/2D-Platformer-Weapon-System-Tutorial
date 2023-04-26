using Bardent.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家攻击状态
/// </summary>
public class PlayerAttackState : PlayerAbilityState
{
    /// <summary>
    /// 武器
    /// </summary>
    private Weapon weapon;

    private int inputIndex;

    public PlayerAttackState(
        Player player,
        PlayerStateMachine stateMachine,
        PlayerData playerData,
        string animBoolName,
        Weapon weapon,
        CombatInputs input
    ) : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;

        inputIndex = (int)input;

        // 订阅事件
        weapon.OnExit += ExitHandler;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        weapon.CurrentInput = player.InputHandler.attackInputs[inputIndex];
    }

    public override void Enter()
    {
        base.Enter();

        weapon.Enter();
    }

    /// <summary>
    /// 攻击动画结束处理
    /// </summary>
    private void ExitHandler()
    {
        AnimationFinishTrigger();
        isAbilityDone = true;
    }
}

