using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampWallState : State {

    private Animator playerAnimator;

    public override void Enter(GameObject Player)
    {


        playerAnimator = Player.GetComponent<Animator>();

        playerAnimator.applyRootMotion = false;

        Player.GetComponent<BoxCollider>().isTrigger = true;

        playerAnimator.SetBool("ClampWall", true);

        Player.GetComponent<Rigidbody>().AddForce(Player.transform.forward * 5);

        Player.GetComponent<Rigidbody>().velocity = Player.transform.forward * 5;

        Player.GetComponent<Rigidbody>().AddForce(new Vector3(0,5,0));

        Player.GetComponent<Rigidbody>().velocity += new Vector3(0, 3, 0);

    }

    public override void Exit()
    {

    }

    public void ExitVault()
    {

        GameObject Player = GameObject.Find("Male");

        Player.GetComponent<Animator>().applyRootMotion = true;

        Player.GetComponent<Animator>().SetBool("ClampWall", false);

        Player.GetComponent<BoxCollider>().isTrigger = false;

        Player.GetComponent<Rigidbody>().useGravity = true;

        PlayerController.playerStateMachine.m_pCurrentState = GameObject.Find("StateManager").GetComponent<IdleState>();
    }

    public override void Execute(GameObject Player)
    {

    }
}
