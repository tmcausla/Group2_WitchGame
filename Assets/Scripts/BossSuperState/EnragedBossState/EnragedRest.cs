using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedRest : EnragedBoss
{
    public EnragedRest(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
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
        boss.counter = 0;
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
        if (boss.counter > 10)
        {
            stateMachine.ChangeState(boss.EnragedChase);
        }
        if(boss.bossHealth.health <= 0)
        {
            boss.Death();
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
