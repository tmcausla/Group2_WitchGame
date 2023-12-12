using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeEnraged : EnragedBoss
{
    public float counter = Time.deltaTime;
    public BecomeEnraged(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        boss.SetVelocityZero();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(counter > 10)
        {
            stateMachine.ChangeState(boss.EnragedChase);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
