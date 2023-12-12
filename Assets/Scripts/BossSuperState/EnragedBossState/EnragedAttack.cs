using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedAttack : EnragedBoss
{

    public bool inRange;
    public EnragedAttack(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        inRange = boss.CheckRange();
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
        if(inRange == false)
        {
            stateMachine.ChangeState(boss.EnragedChase);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
