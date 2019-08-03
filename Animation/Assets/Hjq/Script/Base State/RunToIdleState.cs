using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToIdleState : State {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Enter(GameObject Player)
    {
        Player.GetComponent<Animator>().SetBool("RunToIdle", true);

        StartCoroutine(StateMachine.YieldAniFinish(Player.GetComponent<Animator>(), "Base Layer.RunToIdle", () => { Exit(); }, 0));

    }

    public override void Exit()
    {
        GameObject.Find("Male").GetComponent<Animator>().SetBool("RunToIdle", false);
    }

    public override void Execute(GameObject Player)
    {

    }
}
