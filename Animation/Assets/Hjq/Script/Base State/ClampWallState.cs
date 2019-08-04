using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampWallState : State {

    private Animator playerAnimator;

    private GameObject m_Player;

    private void Start()
    {
        m_Player = gameObject;

        playerAnimator = m_Player.GetComponent<Animator>();

    }

    public override void Enter(GameObject Player)
    {

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

        m_Player.GetComponent<Animator>().applyRootMotion = true;

        m_Player.GetComponent<Animator>().SetBool("ClampWall", false);

        m_Player.GetComponent<BoxCollider>().isTrigger = false;

        m_Player.GetComponent<Rigidbody>().useGravity = true;

        m_Player.GetComponent<PlayerController>().playerStateMachine.m_pCurrentState = m_Player.GetComponent<IdleState>();
    }

    public override void Execute(GameObject Player)
    {

    }
}
