using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState
{
    protected Boss boss;
    protected BossStateMachine stateMachine;
    protected BossData bossData;


    protected bool isAnimationFinished;
    protected bool isExitingState;

    protected float startTime;


    private string animBoolName;


    public BossState(Boss boss, BossStateMachine stateMachine, BossData bossdata, string animBoolName)
    {
        this.boss = boss;
        this.stateMachine = stateMachine;
        this.bossData = bossdata;
        this.animBoolName = animBoolName;

    }

    public virtual void Enter()
    {
        DoChecks();
        boss.Anim.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        boss.Anim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {

    }


    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;


}
