using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBackState : State {


    public GameObject m_player;

    public override void Enter(GameObject Player)
    {

        Player.GetComponent<Animator>().applyRootMotion = false;

        Player.GetComponent<Rigidbody>().velocity = Player.transform.forward * -4;

        Player.GetComponent<Rigidbody>().AddForce(Player.transform.forward * -3);

        Player.GetComponent<Animator>().SetBool("WalkBack", true);

        Debug.LogWarning(Player.GetComponent<Rigidbody>().velocity);
    }

    public override void Exit()
    {

    }

    public override void Execute(GameObject Player)
    {
    }
}
