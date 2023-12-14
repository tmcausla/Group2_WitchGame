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
        
    }

    public override void Enter()
    {
        base.Enter();
        boss.ChargeDirection();
        boss.counter = 0;
        boss.StartCharge();
        boss.SetChargeVelocity(bossData.charge);
    }

    public override void Exit()
    {
        base.Exit();
        doneCharge = false;
        boss.counter = 0;
        boss.ChargeDirection();
        boss.SetVelocityZero();
        boss.ReturnToMiddle();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (doneCharge)
        {
 
            stateMachine.ChangeState(boss.RestTime);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
