using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAttackState : State {

    public override void Enter(GameObject Player)
    {
        Player.GetComponent<Animator>().SetFloat("SecondAttack", 2.0f);

    }

    public override void Execute(GameObject Player)
    {

    }

    public override void Exit()
    {
    }

    public void ExitSecond()
    {

        if (PlayerController.playerStateMachine.m_pCurrentState.GetType() == typeof(SecondAttackState))
        {
            PlayerController.playerStateMachine.m_pCurrentState = GameObject.Find("StateManager").GetComponent<FightIdleState>();

            Debug.LogWarning("2");
        }

    }

    public void SecondFinish()
    {
        GameObject.Find("Male").GetComponent<Animator>().SetFloat("SecondAttack", 0.0f);
    }
}
