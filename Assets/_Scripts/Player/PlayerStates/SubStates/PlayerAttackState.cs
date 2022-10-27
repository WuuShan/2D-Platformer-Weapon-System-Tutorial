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

    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Weapon weapon)
        : base(player, stateMachine, playerData, animBoolName)
    {
        this.weapon = weapon;
    }

    public override void Enter()
    {
        base.Enter();

        weapon.Enter();
    }
}

