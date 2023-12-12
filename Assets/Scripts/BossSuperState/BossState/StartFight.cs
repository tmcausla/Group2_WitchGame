using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : NormalBoss
{
    public float counter;
    public StartFight(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        counter = Time.deltaTime;
        boss.SetVelocityZero();
    }

    public override void Exit()
    {
        base.Exit();
        counter = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (counter > 10)
        {
            stateMachine.ChangeState(boss.NormalChase);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
