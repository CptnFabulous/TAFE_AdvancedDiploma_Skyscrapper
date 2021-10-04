﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack", menuName = "EnemyStates/Attack/Default", order = 1)]
public class EnemyAttack : BaseState
{
    protected float timer = 0;
    public float waitTime = 2;

    public override BaseState GetStateCopy()
    {
        EnemyAttack newState = CreateInstance<EnemyAttack>();
        newState.SetValues(waitTime);
        return newState;
    }

    private void SetValues(float _waitTime)
    {
        waitTime = _waitTime;
    }

    public override void EnterState()
    {
        base.EnterState();
        machine.SetAnimTrigger("Attack");
        Debug.Log("attack start" + machine.name);
    }

    public override void UpdateState()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            Debug.Log("attack's over");
            machine.ChangeState(machine.GetIdle().GetStateCopy());
        }
    }
}