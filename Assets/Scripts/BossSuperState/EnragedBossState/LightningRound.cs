using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRound : EnragedBoss
{
    public float counter;
    public LightningRound(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
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
        boss.LightningAttack();
    }

    public override void Exit()
    {
        base.Exit();
        boss.counter = 0;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(boss.counter > 3)
        {
            stateMachine.ChangeState(boss.EnragedRest);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
