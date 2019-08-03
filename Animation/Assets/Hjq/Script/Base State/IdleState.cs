using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 玩家待机状态
/// </summary>
public class IdleState : State
{
    private Animator playerAnimator;
    public override void Enter(GameObject Player)
    {
        if (Player.GetComponent<Animator>() != null)
        {
            playerAnimator = Player.GetComponent<Animator>();

            playerAnimator.SetBool("FirstJump", false);
            playerAnimator.SetBool("SecondJump", false);
            playerAnimator.SetBool("PreAttack", false);
            playerAnimator.SetBool("FightIdle", false);

            playerAnimator.SetFloat("Speed", 0.0f);
            playerAnimator.SetFloat("Angle", 0.0f);

            //playerAnimator.SetBool("")
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

    }


}