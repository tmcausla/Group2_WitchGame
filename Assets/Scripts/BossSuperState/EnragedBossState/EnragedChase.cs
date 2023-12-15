using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnragedChase : EnragedBoss
{
    public bool inRange;
    public EnragedChase(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
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
    }

    public override void Exit()
    {
        base.Exit();
        inRange = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        boss.CheckIfShouldFlip();
        boss.SetVelocityX(bossData.angryChase);
        if (inRange)
        {
            stateMachine.ChangeState(boss.EnragedAttack);
        }
        else if(boss.counter > 15f)
        {
            stateMachine.ChangeState(boss.EnragedCharge);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
