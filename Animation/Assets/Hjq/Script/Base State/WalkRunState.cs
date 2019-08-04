using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 动画树混合的走,跑状态
/// </summary>
public class WalkRunState : State
{
    float Speed = 0.0f;
    float Angle = 0.0f;
    private Animator playerAnimator;

    private StateMachine playerStateMachine;

    public GameObject m_player;

    private void Start()
    {

        m_player = gameObject;

        playerAnimator = m_player.GetComponent<Animator>();

        playerStateMachine = m_player.GetComponent<PlayerController>().playerStateMachine;
    }

    public override void Enter(GameObject Player)
    {

        if (Player.GetComponent<Animator>() != null)
        {
            playerAnimator = Player.GetComponent<Animator>();
        }

        Angle = Player.GetComponent<PlayerController>().Angle;

        if (PlayerController.speedUp)
        {
            Speed += 0.5f * Player.GetComponent<PlayerController>().Speed;
        }


        else 
        {
            Speed = 0.5f * Player.GetComponent<PlayerController>().Speed;
        }


        Angle = Angle * 10;

        playerAnimator.SetBool("IdleToRun", true);

        playerAnimator.SetFloat("Speed", Speed);
        playerAnimator.SetFloat("Angle", Angle);


        StartCoroutine(StateMachine.YieldAniFinish(Player.GetComponent<Animator>(), "Base Layer.BlendRun", () => { Exit(); }, 0));

        if (Speed < 0.07f && Player.GetComponent<PlayerController>().playerStateMachine.m_pCurrentState.GetType() 
            == typeof(WalkRunState)
            )
        {
            //playerAnimator.SetBool("IdleToRun", false);
        }

    }

    /// <summary>
    /// 更新状态函数
    /// </summary>
    public override void Execute(GameObject Player)
    {
    }


    /// <summary>
    /// 当状态退出时执行这个函数
    /// </summary>
    public override void Exit()
    {
        Angle = 0.0f;

        if (playerAnimator.GetFloat("Speed") < 0.01f)
        {
            //if(PlayerController.speedUp)
            //{
            //}

            playerAnimator.SetBool("IdleToRun", false);
            if (playerAnimator.GetCurrentAnimatorStateInfo(1).IsName("Swort Layer.IdletoFight"))
            {
                playerStateMachine.m_pCurrentState = m_player.GetComponent<FightIdleState>();
            }
            else
            {
                playerStateMachine.m_pCurrentState = m_player.GetComponent<IdleState>();

            }
        }
    }

}
