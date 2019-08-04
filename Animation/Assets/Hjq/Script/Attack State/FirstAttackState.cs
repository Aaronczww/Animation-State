using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAttackState : State {

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

        Player.GetComponent<Animator>().SetFloat("FirstAttack", 1.0f);


        m_Player = Player;


        //StartCoroutine(StateMachine.YieldAniFinish(Player.GetComponent<Animator>(), "Attack Layer.Attact01A", () => { Exit(Player); },2));
    }

    public override void Execute(GameObject Player)
    {

    }

    public override void Exit()
    {

        if(stateMachine.m_pCurrentState.GetType() == typeof(FirstAttackState))
        {
            stateMachine.m_pCurrentState = m_Player.GetComponent<FightIdleState>();


        }

    }

    public void FirstFinish()
    {
        playerAnimator = m_Player.GetComponent<Animator>();

        playerAnimator.SetFloat("FirstAttack", 0.0f);
    }

}
