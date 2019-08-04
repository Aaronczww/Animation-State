using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightIdleState : State {

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


        Player.GetComponent<Animator>().SetBool("FightIdle", true);

    }

    public override void Execute(GameObject Player)
    {
    }

    public override void Exit()
    {
    }

    public void IdleFinish()
    {

        playerAnimator = m_Player.GetComponent<Animator>();

        playerAnimator.SetBool("FightIdle", false);

        stateMachine.m_pCurrentState = m_Player.GetComponent<IdleState>();
    }
}
