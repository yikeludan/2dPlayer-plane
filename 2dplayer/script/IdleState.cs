
using UnityEngine;


public class IdleState : IState
{

    private FSM fsm;

    private Paramter par;


    private AnimatorStateInfo animatorStateInfo;

    private float idleTime = 0f;

    private bool isIdle = true;
    public IdleState(FSM manager)
    {
        this.fsm = manager;
        this.par = manager.par;

    }


    public void OnEnter()
    {
        this.par.an.Play("sidel");
        this.animatorStateInfo = this.par.an.GetCurrentAnimatorStateInfo(0);

    }



    public void OnUpdate()
    {
        
        animatorStateInfo = this.par.an.GetCurrentAnimatorStateInfo(0);
        if (idleTime >= 3)
        {
            idleTime = 0f;
            this.fsm.TransitionState(StateType.Patrol);
        }
        idleTime += Time.deltaTime;
    }

    public void OnExit()
    {
        this.isIdle = false;
    }

}

public class PatrolState : IState
{
    private FSM fsm;

    private Paramter par;

    private Vector3 targetVec3;

    private Vector3 dir = new Vector3(-99999f, 9999f, 0);

    private AnimatorStateInfo animatorStateInfo;

    private bool isWalk = true;

    public PatrolState(FSM manager)
    {
        this.fsm = manager;
        this.par = manager.par;
    }
    public void OnEnter()
    {
        this.par.an.Play("swalk");
        this.RandomWalkPos();
    }

    void RandomWalkPos()
    {
        if (this.fsm.par.isAttackSwtichPatrol)
        {
            return;
        }
        float x = Random.Range(this.par.startPos.position.x, this.par.endPos.position.x);
        targetVec3 = new Vector3(x, this.fsm.transform.position.y, 0);
        dir = (this.targetVec3 - this.fsm.transform.position).normalized;
        this.par.isLeft = false;
        if (dir.x < 0)
        {
            this.par.isLeft = true;
        }
    }

    public void OnUpdate()
    {
        
        if (this.fsm.par.SArea.isSarea)
        {
            if (Physics2D.OverlapCircle(this.fsm.transform.position, 0.7f, this.fsm.par.targetLayer))
            {
                this.fsm.TransitionState(StateType.Attack);
            }
            else
            {
                // this.fsm.TransitionState(StateType.Patrol);
                //                Debug.Log("sera false");
            }
            //在区域内 骷髅 跟随
            Vector3 followDir = (this.targetVec3 - this.fsm.transform.position).normalized;
            this.fsm.transform.Translate(followDir * Time.deltaTime, Space.World);
        }
        else
        {
            if (Vector3.Distance(this.fsm.transform.position, this.targetVec3) >= 0.1f)
            {
                this.fsm.transform.Translate(dir * Time.deltaTime, Space.World);
                Quaternion rotation = Quaternion.Euler(this.fsm.transform.rotation.x,
                    this.par.isLeft == true ? 180 : 0,
                    this.fsm.transform.rotation.z);
                this.fsm.transform.rotation = rotation;
            }
            else
            {
                this.fsm.par.isAttackSwtichPatrol = false;
                this.RandomWalkPos();
            }
        }


    }

    public void OnExit()
    {
        this.isWalk = false;
    }
}


public class Attack : IState
{

    private FSM fsm;

    private Paramter par;

    private bool isAttack = true;


    private AnimatorStateInfo info;

    public Attack(FSM manager)
    {
        this.fsm = manager;
        this.par = manager.par;
    }

    public void OnEnter()
    {

        this.par.an.Play("sAttack",0, 0f);
    }
    public void OnUpdate()
    {


        if (!Physics2D.OverlapCircle(this.fsm.transform.position, 0.7f, this.fsm.par.targetLayer))
        {

            info = this.fsm.par.an.GetCurrentAnimatorStateInfo(0);

            if (info.IsName("sAttack"))
            {
                if (info.normalizedTime > 1.0f)
                {
                    Debug.Log("动画播放完毕 转向 行走");
                    this.fsm.par.isAttackSwtichPatrol = true;
                    this.fsm.TransitionState(StateType.Patrol);
                }else{

                }
            }

            //this.fsm.TransitionState(StateType.Attack);
            // Debug.Log("attack sera");

        }
        // if (!this.fsm.par.SArea.isSarea)
        // {
        //     this.fsm.TransitionState(StateType.Patrol);
        // }
    }

    public void OnExit()
    {
        isAttack = false;
    }
}


public class Hit : IState
{

    private FSM fsm;

    private Paramter par;

    private bool isAttack = true;


    private AnimatorStateInfo info;

    public Hit(FSM manager)
    {
        this.fsm = manager;
        this.par = manager.par;
    }

    public void OnEnter()
    {

        this.par.an.Play("shit", 0, 0f);
        this.par.health -=20;
    }
    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}


public class Dead : IState
{

    private FSM fsm;

    private Paramter par;

    private bool isAttack = true;


    private AnimatorStateInfo info;

    public Dead(FSM manager)
    {
        this.fsm = manager;
        this.par = manager.par;
    }

    public void OnEnter()
    {

        this.par.an.Play("sDead");
        
       // this.par.health -=20;
    }
    public void OnUpdate()
    {

    }

    public void OnExit()
    {
    }
}
