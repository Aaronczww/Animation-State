using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondJump : State
{
    private Animator playerAnimator;

    private Rigidbody playerRigidBody;

    private StateMachine stateMachine;

    private IdleState idleState;

    private bool _canJump;

    public int count = 0;

    private GameObject m_player;

    private void Start()
    {

        idleState = GetComponent<IdleState>();

        m_player = gameObject;

        playerAnimator = m_player.GetComponent<Animator>();

        stateMachine = m_player.GetComponent<PlayerController>().playerStateMachine;

        playerRigidBody = m_player.GetComponent<Rigidbody>();


    }

    public override void Enter(GameObject Player)
    {
        /// 二段跳只在上一个是跳跃的状态下触发
        if (stateMachine.m_pPreviousState.GetType() == typeof(JumpState) && count == 0
            && Player.GetComponent<JumpState>().secondJumpinterval < 0.45f)
        {
            Debug.LogWarning("二段跳");
            //Debug.LogWarning(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Jump01"));

            playerAnimator.SetBool("SecondJump", true);

            count = 1;
                
            playerRigidBody.AddForce(0, 10, 0);

            playerRigidBody.velocity += new Vector3(0, 5, 0);

            StartCoroutine(StateMachine.YieldAniFinish(playerAnimator, "Base Layer.Jump02", () => { Exit(); },0));

            _canJump = true;

            Player.GetComponent<JumpState>().secondJumpinterval = 0.0f;

        }
    }
    public override void Execute(GameObject Player)
    {

    }
    /// <summary>
    /// 退出时回到idle
    /// </summary>
    /// <param name="Player"></param>
    public override void Exit()
    {
        playerAnimator.SetBool("SecondJump", false);
    }
}
