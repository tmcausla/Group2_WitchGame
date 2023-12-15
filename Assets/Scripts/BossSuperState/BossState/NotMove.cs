using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotMove : NormalBoss
{
    public bool startMove;
    public NotMove(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName) : base(boss, stateMachine, bossdata, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        startMove = boss.SeePlayer();
    }

    public override void Enter()
    {
        base.Enter();
        boss.bossHealth.isInvulnerable = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (startMove)
        {
            stateMachine.ChangeState(boss.StartFight);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
