using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForthAttackState : State {

    private StateMachine stateMachine;

    private Animator playerAnimator;



    private GameObject m_Player;

    private void Start()
    {
        m_Player = this.gameObject;

        playerAnimator = m_Player.GetComponent<Animator>();

        stateMachine = m_Player.GetComponent<PlayerController>().playerStateMachine;
    }

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

        if (stateMachine.m_pCurrentState.GetType() == typeof(ForthAttackState))
        {
            stateMachine.m_pCurrentState = m_Player.GetComponent<FightIdleState>();

        }
    }

    public void ForthdFinish()
    {
        playerAnimator.SetFloat("ForthAttack", 0.0f);
    }
}
