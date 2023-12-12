using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestTime : NormalBoss
{
    public BossHealth bossHealth;
    public float counter = Time.deltaTime;
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
        bossHealth.isInvulnerable = false;
    }

    public override void Exit()
    {
        base.Exit();
        bossHealth.isInvulnerable = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(counter > 20)
        {
            stateMachine.ChangeState(boss.NormalChase);
        }
        else if (bossHealth.health < 50)
        {
            stateMachine.ChangeState(boss.BecomeEnraged);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
