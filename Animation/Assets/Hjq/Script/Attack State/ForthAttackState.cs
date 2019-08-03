using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForthAttackState : State {


    public override void Enter(GameObject Player)
    {
        Player.GetComponent<Animator>().SetFloat("ForthAttack", 2.0f);
    }

    public override void Execute(GameObject Player)
    {

    }

    public override void Exit()
    {
   
    }

    public void ExitForth()
    {

        if (PlayerController.playerStateMachine.m_pCurrentState.GetType() == typeof(ForthAttackState))
        {
            PlayerController.playerStateMachine.m_pCurrentState = GameObject.Find("StateManager").GetComponent<FightIdleState>();

            Debug.LogWarning("4");
        }
    }

    public void ForthdFinish()
    {
        GameObject.Find("Male").GetComponent<Animator>().SetFloat("ForthAttack", 0.0f);
    }
}
