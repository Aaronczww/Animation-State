using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAttackState : State {

    public override void Enter(GameObject Player)
    {

        Player.GetComponent<Animator>().SetFloat("FirstAttack", 1.0f);

        //StartCoroutine(StateMachine.YieldAniFinish(Player.GetComponent<Animator>(), "Attack Layer.Attact01A", () => { Exit(Player); },2));
    }

    public override void Execute(GameObject Player)
    {

    }

    public override void Exit()
    {

        if(PlayerController.playerStateMachine.m_pCurrentState.GetType() == typeof(FirstAttackState))
        {
            PlayerController.playerStateMachine.m_pCurrentState = GameObject.Find("StateManager").GetComponent<FightIdleState>();

            Debug.LogWarning("1");
        }

    }

    public void FirstFinish()
    {
        GameObject.Find("Male").GetComponent<Animator>().SetFloat("FirstAttack", 0.0f);
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
