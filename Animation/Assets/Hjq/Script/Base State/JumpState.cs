using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 跳跃加二段跳
/// </summary>
public class JumpState : State
{
    private Animator playerAnimator;

    private Rigidbody playerRigidBody;

    private StateMachine stateMachine;


    private SecondJump secondJump;

    private IdleState idleState;

    public float secondJumpinterval;


    public GameObject m_player;

    private void Start()
    {

        m_player = gameObject;

        playerRigidBody = m_player.GetComponent<Rigidbody>();

        playerAnimator = m_player.GetComponent<Animator>();

        stateMachine = m_player.GetComponent<PlayerController>().playerStateMachine;
    }

    private void Awake()
    {

        secondJump = GetComponent<SecondJump>();

        idleState = GetComponent<IdleState>();
    }

    public override void Enter(GameObject Player)
    {
        ///奔跑时跳跃
        if (Player.GetComponent<PlayerController>().Speed > 0)
        {

            playerRigidBody.AddForce(Player.transform.forward * 15);

            playerRigidBody.velocity = Player.transform.forward * 10;
        }

        ///二段跳

        ///一段跳
        if (stateMachine.m_pPreviousState.GetType() == typeof(IdleState) 
            
            || stateMachine.m_pPreviousState.GetType() == typeof(WalkRunState)
            
            || stateMachine.m_pPreviousState.GetType() == typeof(AttackPreState))
        {
            secondJumpinterval = 0.0f;

            playerAnimator.SetBool("FirstJump", true);

            playerRigidBody.AddForce(0, 5, 0);

            playerRigidBody.velocity = new Vector3(0, 5, 0);

            StartCoroutine(StateMachine.YieldAniFinish(playerAnimator, "Base Layer.Jump01", () => { Exit(); },0));

        }

        else if (stateMachine.m_pPreviousState.GetType() == typeof(JumpState))
        {
            Execute(Player);
        }

    }

    /// <summary>
    /// 更新状态函数
    /// </summary>
    public override void Execute(GameObject Player)
    {
        stateMachine.ChangeState(secondJump);
    }

    /// <summary>
    /// 当状态退出时执行这个函数
    /// </summary>
    public override void Exit()
    {
        playerAnimator.SetBool("FirstJump", false);
        playerAnimator.SetBool("PreAttack", false);
    }

    private void FixedUpdate()
    {
        secondJumpinterval += Time.deltaTime;
    }

}
