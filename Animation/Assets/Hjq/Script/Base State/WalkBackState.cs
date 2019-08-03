using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBackState : State {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Enter(GameObject Player)
    {
        Player.GetComponent<Animator>().SetBool("WalkBack", true);

        Player.GetComponent<Animator>().applyRootMotion = false;

        Player.GetComponent<Rigidbody>().velocity = Player.transform.forward * -3;

    }

    public override void Exit()
    {

    }

    public override void Execute(GameObject Player)
    {
    }
}
