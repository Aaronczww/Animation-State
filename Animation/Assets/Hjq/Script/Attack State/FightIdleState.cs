using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightIdleState : State {

    private StateMachine stateMachine;

    void Start()
    {
        stateMachine = PlayerController.playerStateMachine;
    }
    public override void Enter(GameObject Player)
    {

        Player.GetComponent<Animator>().SetBool("FightIdle", true);

        //StartCoroutine(EarylyExit(Player));

        StartCoroutine(StateMachine.YieldAniFinish(Player.GetComponent<Animator>(), "Swort Layer.IdleFight", () => { Exit(); },2));


    }

    public override void Execute(GameObject Player)
    {
    }

    public override void Exit()
    {
        GameObject.Find("Male").GetComponent<Animator>().SetBool("FightIdle", false);

        PlayerController.playerStateMachine.m_pCurrentState = GameObject.Find("StateManager").GetComponent<IdleState>();
    }
}
