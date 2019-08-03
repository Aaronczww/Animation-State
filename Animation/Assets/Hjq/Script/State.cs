using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    /// <summary>
    /// 当状态被进入时执行这个函数
    /// </summary>
    public abstract void Enter(GameObject Player);

    /// <summary>
    /// 更新状态函数
    /// </summary>
    public abstract void Execute(GameObject Player);


    /// <summary>
    /// 当状态退出时执行这个函数
    /// </summary>
    public abstract void Exit();

}
