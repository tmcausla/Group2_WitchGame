using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : NormalBoss
{
    public StartFight(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        boss.counter = 0f;
        boss.bossHealth.isInvulnerable = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (boss.counter > bossData.change)
        {
            stateMachine.ChangeState(boss.NormalChase);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
