using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAttackState : State {

    private Animator playerAnimator;

    private StateMachine stateMachine;

    private GameObject m_Player;

    private void Start()
    {
        m_Player = this.gameObject;

        playerAnimator = m_Player.GetComponent<Animator>();

        stateMachine = m_Player.GetComponent<PlayerController>().playerStateMachine;
    }
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
        

        if (stateMachine.m_pCurrentState.GetType() == typeof(SecondAttackState))
        {
            stateMachine.m_pCurrentState = m_Player.GetComponent<FightIdleState>();


        }

    }

    public void SecondFinish()
    {
        playerAnimator.SetFloat("SecondAttack", 0.0f);
    }
}
