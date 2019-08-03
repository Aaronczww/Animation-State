using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StateMachine : MonoBehaviour
{
    private GameObject m_pOwner;
    public State m_pCurrentState;
    public State m_pPreviousState;
    private State m_pGlobalState;


    public StateMachine(GameObject owner)
    {
        m_pOwner = owner;

        m_pPreviousState = null;

    }

    public void SetCurrentState(State state)
    {
        m_pCurrentState = state;
    }

    public void SetPreviousState(State state)
    { 
        m_pPreviousState = state;
    }

    public void SetGlobalState(State state)
    {
        m_pGlobalState = state;
    }

    public void StateMachineUpdate()
    {
        // 如果有一个全局状态存在，调用它的执行方法
        if (m_pGlobalState != null)
        {
            m_pGlobalState.Execute(m_pOwner);
        }

        if (m_pCurrentState != null)
        {
            m_pCurrentState.Execute(m_pOwner);
        }
    }

    public void ChangeState(State newState)
    {
        m_pPreviousState = m_pCurrentState;
        //m_pCurrentState.Exit(m_pOwner);
        m_pCurrentState = newState;
        m_pCurrentState.Enter(m_pOwner);
    }

    /// <summary>
    /// 返回之前的状态
    /// </summary>
    public void RevertToPreviousState()
    {
        ChangeState(m_pPreviousState);
    }

    public State CurrentState()
    {
        return m_pCurrentState;
    }

    public State PreviousState()
    {
        return m_pPreviousState;
    }

    public State GlobalState()
    {
        return m_pGlobalState;
    }

    public bool IsInState(State state)
    {
        return m_pCurrentState == state;
    }

        /// <summary>
        /// 动画事件回调
        /// </summary>
        /// <param name="ani"></param>
        /// <param name="aniName"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// 
    public static IEnumerator YieldAniFinish(Animator ani, string tagName, UnityAction action ,int layerindex)
    {
        float cdtime = 0.0f;

        AnimatorStateInfo stateinfo = ani.GetCurrentAnimatorStateInfo(layerindex);

        while (true)
        {
            yield return null;

            cdtime += Time.deltaTime;

            if (stateinfo.normalizedTime > 1.0f)
            {
                action();
                break;
            }
        }
    }
}
