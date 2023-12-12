using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCharge : NormalBoss
{

    private bool doneCharge;
    public NormalCharge(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        doneCharge = boss.CheckCharge();
        boss.ChargeDirection();
    }

    public override void Enter()
    {
        base.Enter();
        boss.counter = 0;
    }

    public override void Exit()
    {
        base.Exit();
        doneCharge = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        boss.StartCharge();
        boss.SetChargeVelocity(bossData.charge);
        if (doneCharge)
        {
            boss.SetVelocityZero();
            boss.ReturnToMiddle();
            stateMachine.ChangeState(boss.RestTime);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
