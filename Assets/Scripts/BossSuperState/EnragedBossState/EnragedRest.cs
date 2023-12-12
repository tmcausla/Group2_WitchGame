using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedRest : EnragedBoss
{
    public BossHealth bossHealth;
    public float counter;
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
        bossHealth.isInvulnerable = false;
        counter = Time.deltaTime;
    }

    public override void Exit()
    {
        base.Exit();
        bossHealth.isInvulnerable = true;
        counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (counter > 20)
        {
            stateMachine.ChangeState(boss.EnragedChase);
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
