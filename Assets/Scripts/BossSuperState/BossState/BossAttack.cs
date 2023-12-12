using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossAttack : NormalBoss
{

    public bool inRange;
    public BossAttack(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
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
            stateMachine.ChangeState(boss.NormalChase);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
