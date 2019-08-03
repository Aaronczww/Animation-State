using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdAttackState : State {

    public override void Enter(GameObject Player)
    {
        Player.GetComponent<Animator>().SetFloat("ThirdAttack", 3.0f);

    }

    public override void Execute(GameObject Player)
    {

    }


    public override void Exit()
    {
        

    }

    public void ExitThird()
    {
        if(PlayerController.playerStateMachine.m_pCurrentState.GetType() == typeof(ThirdAttackState))
        {
            PlayerController.playerStateMachine.m_pCurrentState = GameObject.Find("StateManager").GetComponent<FightIdleState>();

            Debug.LogWarning("3");
        }
    }

    public void ThirdFinish()
    {
        GameObject.Find("Male").GetComponent<Animator>().SetFloat("ThirdAttack", 0.0f);
    }
}
