using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPreState : State {

    private StateMachine stateMachine;
    void Start()
    {
        stateMachine = PlayerController.playerStateMachine;
    }
    public override void Enter(GameObject Player)
    {
        //Player.GetComponent<Animator>().SetLayerWeight(1, 1);

        Player.GetComponent<Animator>().SetBool("PreAttack", true);

        StartCoroutine(StateMachine.YieldAniFinish(Player.GetComponent<Animator>() , "Swort Layer.IdletoFight", () => { Exit(); },1));
    }
    public override void Execute(GameObject Player)
    {

    }
    public override void Exit()
    {
        GameObject.Find("Male").GetComponent<Animator>().SetBool("PreAttack", false);

    }
}
