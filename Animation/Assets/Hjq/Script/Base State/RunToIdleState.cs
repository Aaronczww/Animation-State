using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunToIdleState : State {

    private Animator playerAnimator;

    public GameObject m_player;

    private void Start()
    {

        m_player = this.gameObject;

        playerAnimator = m_player.GetComponent<Animator>();
    }

    public override void Enter(GameObject Player)
    {
        playerAnimator = Player.GetComponent<Animator>();

        Player.GetComponent<Animator>().SetBool("RunToIdle", true);

        StartCoroutine(StateMachine.YieldAniFinish(Player.GetComponent<Animator>(), "Base Layer.RunToIdle", () => { Exit(); }, 0));

    }

    public override void Exit()
    {
        playerAnimator.SetBool("RunToIdle", false);
    }

    public override void Execute(GameObject Player)
    {

    }
}
