using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestTime : NormalBoss
{
    public RestTime(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        boss.bossHealth.isInvulnerable = false;
    }

    public override void Exit()
    {
        base.Exit();
        boss.bossHealth.isInvulnerable = true;
        boss.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(boss.counter > 10f)
        {
            stateMachine.ChangeState(boss.NormalChase);
        }
        else if (boss.bossHealth.health < 50)
        {
            stateMachine.ChangeState(boss.BecomeEnraged);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
