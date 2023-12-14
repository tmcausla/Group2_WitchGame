using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalChase : NormalBoss
{

    private bool inRange;

    public NormalChase(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
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
        boss.SetVelocityX(bossData.normalSpeed);
        if (inRange)
        {
            stateMachine.ChangeState(boss.BossAttack);
        }
        else if (boss.counter > 15f)
        {
            stateMachine.ChangeState(boss.NormalCharge);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
