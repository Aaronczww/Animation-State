using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public StateMachine playerStateMachine;
    public Animator animator;


    public float Speed;
    public float Angle;

    private IdleState idleState;
    private WalkRunState walkState;
    private JumpState jumpState;
    private SecondJump secondJump;
    private ClampWallState clampWallState;
    private WalkBackState walkBackState;
    private AwayGroundState awayGroundState;


    private AttackPreState attackPreState;
    private FirstAttackState firstattackState;
    private SecondAttackState secondAttackState;
    private ThirdAttackState thirdAttackState;
    private ForthAttackState forthAttackState;
    private FightIdleState fightIdleState;

    private float attackCDTime;

    public State CurrentState;

    //public GameObject StateManager;

    public static bool speedUp = false;

    private RaycastHit hitinfo;

    /// <summary>
    ///开启IK动画
    /// </summary>
    public bool ikActive;

    public bool _canJump = true;

    private float jumpCdTime;

    private float attackSecondTime;

    private void Awake()
    {
        hitinfo = new RaycastHit();

        jumpCdTime = 0.0f;

        attackCDTime = 0.0f;

        attackSecondTime = 0.0f;


        playerStateMachine = new StateMachine(gameObject);

        idleState = GetComponent<IdleState>();
        walkState = GetComponent<WalkRunState>();
        jumpState = GetComponent<JumpState>();
        secondJump = GetComponent<SecondJump>();
        clampWallState = GetComponent<ClampWallState>();
        walkBackState = GetComponent<WalkBackState>();
        awayGroundState = GetComponent<AwayGroundState>();


        attackPreState = GetComponent<AttackPreState>();
        firstattackState = GetComponent<FirstAttackState>();
        secondAttackState = GetComponent<SecondAttackState>();
        thirdAttackState = GetComponent<ThirdAttackState>();
        forthAttackState = GetComponent<ForthAttackState>();
        fightIdleState = GetComponent<FightIdleState>();

        CurrentState = idleState;

        animator = GetComponent<Animator>();

        ikActive = false;

        playerStateMachine.m_pCurrentState = idleState;

        
    }

    private void FixedUpdate()
    {
        jumpCdTime += Time.fixedDeltaTime;

        attackCDTime += Time.fixedDeltaTime;

        Speed = Input.GetAxis("Vertical");
        Angle = Input.GetAxis("Horizontal");

        attackSecondTime += Time.fixedDeltaTime;

        //后退

        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    GetComponent<Animator>().SetBool("WalkBack", false);

        //    GetComponent<Animator>().applyRootMotion = true;

        //    GetComponent<Rigidbody>().velocity = Vector3.zero;

        //    Debug.LogWarning("2223");

        //    playerStateMachine.m_pCurrentState = GetComponent<IdleState>();
        //}

        //if (Input.GetKey(KeyCode.S))
        //{

        //    if(playerStateMachine.m_pCurrentState.GetType() == typeof(IdleState)
        //        ||
        //    GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Swort Layer.IdletoFight")
        //        ||
        //        playerStateMachine.m_pCurrentState.GetType() == typeof(WalkRunState))
        //    {
        //        Speed = 0;

        //        playerStateMachine.ChangeState(walkBackState);
        //    }
        //}


        //跑
        if (Angle != 0 || Speed != 0)
        {
            if (playerStateMachine.m_pCurrentState.GetType() == typeof(JumpState)
                || playerStateMachine.m_pCurrentState.GetType() == typeof(SecondJump)
                || playerStateMachine.m_pCurrentState.GetType() == typeof(ClampWallState)
                || playerStateMachine.m_pCurrentState.GetType() == typeof(AwayGroundState)
                )
            {
                return;
            }


            playerStateMachine.ChangeState(walkState);
        }

        //轻击
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCDTime > 0.15f)
        {
            attackCDTime = 0.0f;

            if (playerStateMachine.m_pCurrentState.GetType()
                == typeof(AttackPreState)
                ||
                playerStateMachine.m_pCurrentState.GetType()
                == typeof(FightIdleState)
                ||
                playerStateMachine.m_pCurrentState.GetType()
                == typeof(WalkRunState))
            {
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Swort Layer.IdletoFight") && Speed < 0.1f)
                {

                    playerStateMachine.ChangeState(firstattackState);
                }

            }
            else if (playerStateMachine.m_pCurrentState.GetType()
                 == typeof(FirstAttackState)
                 )
            {
                playerStateMachine.ChangeState(secondAttackState);
            }


            else if (playerStateMachine.m_pCurrentState.GetType()
                 == typeof(SecondAttackState))
            {
                playerStateMachine.ChangeState(forthAttackState);
            }
        }


    }


    void Update()
    {

        if (Input.anyKeyDown)
        {
            Debug.LogWarning(playerStateMachine.m_pCurrentState);
        }

        //跳

        if (Input.GetKeyDown(KeyCode.Space) && jumpCdTime > 0.15f)
        {

            if (Physics.Raycast(this.transform.position + Vector3.up * 0.4f, this.transform.forward
                , out hitinfo, 2.0f))
            {
                if (hitinfo.collider.gameObject.tag == "Wall")
                {
                    playerStateMachine.ChangeState(clampWallState);
                }
            }

            if (playerStateMachine.m_pCurrentState.GetType() == typeof(IdleState)

            || playerStateMachine.m_pCurrentState.GetType() == typeof(WalkRunState)

            || playerStateMachine.m_pCurrentState.GetType() == typeof(AttackPreState))
            {
                playerStateMachine.ChangeState(jumpState);

            }

            else if (playerStateMachine.m_pCurrentState.GetType() == typeof(JumpState))
            {


                playerStateMachine.ChangeState(secondJump);

            }
  

            this.GetComponent<Animator>().applyRootMotion = false;


            jumpCdTime = 0.0f;

        }

        //重击

        if(Input.GetKeyDown(KeyCode.Mouse1) && attackSecondTime > 0.2f)
        {

            attackSecondTime = 0.0f;


            if (playerStateMachine.m_pCurrentState.GetType()
                 == typeof(SecondAttackState)
                 ||
                 playerStateMachine.m_pCurrentState.GetType()
                 == typeof(SecondJump))
            {

                playerStateMachine.ChangeState(thirdAttackState);
            }

            else if (playerStateMachine.m_pCurrentState.GetType()
                  == typeof(ThirdAttackState))
            {
                playerStateMachine.ChangeState(forthAttackState);
            }

            if (playerStateMachine.m_pCurrentState.GetType()
                == typeof(AttackPreState)
                ||
                playerStateMachine.m_pCurrentState.GetType()
                == typeof(FightIdleState)
                )
            {
                if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(1).IsName("Swort Layer.IdletoFight") && Speed < 0.001f)
                {

                    playerStateMachine.ChangeState(forthAttackState);

                    Debug.LogWarning(playerStateMachine.m_pCurrentState);
                }
            }
        }

        /// 收武器
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            if(playerStateMachine.m_pCurrentState.GetType()
            == typeof(AttackPreState)
            ||
            playerStateMachine.m_pCurrentState.GetType()
            == typeof(WalkRunState))
            {

                playerStateMachine.m_pCurrentState = idleState;

                fightIdleState.Enter(this.gameObject);

            }

        }
        ///拿武器
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(playerStateMachine.m_pCurrentState.GetType()
            == typeof(IdleState)
            ||playerStateMachine.m_pCurrentState.GetType()
                ==typeof(WalkRunState)
            ||
            playerStateMachine.m_pCurrentState.GetType()
                == typeof(WalkBackState))
            {
                playerStateMachine.ChangeState(attackPreState);
            }
        }

        ///加速
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedUp = true;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedUp = false;
        }

    }
    /// <summary>
    /// 碰撞检测
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            this.GetComponent<Animator>().applyRootMotion = true;

            jumpCdTime = 0.0f;

            idleState.Enter(gameObject);

            playerStateMachine.m_pCurrentState = idleState;

            GetComponent<SecondJump>().count = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            playerStateMachine.m_pCurrentState = awayGroundState;
        }
    }
}
