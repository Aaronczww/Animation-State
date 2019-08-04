using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdAttackState : State {

    private StateMachine stateMachine;

    private Animator playerAnimator;

    private GameObject m_player;

    private void Start()
    {

        m_player = this.gameObject;

        playerAnimator = m_player.GetComponent<Animator>();

        stateMachine = m_player.GetComponent<PlayerController>().playerStateMachine;
    }

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
        if(stateMachine.m_pCurrentState.GetType() == typeof(ThirdAttackState))
        {
            stateMachine.m_pCurrentState = m_player.GetComponent<FightIdleState>();

        }
    }

    public void ThirdFinish()
    {
        playerAnimator.SetFloat("ThirdAttack", 0.0f);
    }
}
