using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPreState : State {

    private StateMachine stateMachine;

    private Animator playerAnimator;

    private GameObject m_Player;

    private void Start()
    {
        m_Player = gameObject;

        Debug.LogWarning(m_Player.name);

        playerAnimator = m_Player.GetComponent<Animator>();

        stateMachine = m_Player.GetComponent<PlayerController>().playerStateMachine;
    }
    public override void Enter(GameObject Player)
    {
        Player.GetComponent<Animator>().SetBool("PreAttack", true);
    }
    public override void Execute(GameObject Player)
    {

    }
    public override void Exit()
    {

    }
    public void FightFinish()
    {

        playerAnimator = m_Player.GetComponent<Animator>();

        playerAnimator.SetBool("PreAttack", false);
    }
}
