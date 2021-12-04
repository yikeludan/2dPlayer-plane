using System.Runtime.CompilerServices;
using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum StateType
{
    Idle, Patrol, Chase, React, Attack, Hit, Death
}
[Serializable]
public class Paramter
{
    public int health = 100;
    public Animator an;
    public Transform startPos;
    public Transform endPos;
    public bool isLeft;

    public bool isAttackSwtichPatrol = false;

    public LayerMask targetLayer;

    public SArea SArea;

    public bool isDead;
}

public class FSM : MonoBehaviour
{
    private IState currentState;
    public Paramter par;
    public Dictionary<StateType, IState> states = new Dictionary<StateType, IState>();
    protected Transform self;

    private AnimatorStateInfo animatorStateInfo;

    private void Awake()
    {
        this.self = this.transform;
        states.Add(StateType.Hit, new Hit(this));
        states.Add(StateType.Idle, new IdleState(this));
        states.Add(StateType.Patrol, new PatrolState(this));
        states.Add(StateType.Attack, new Attack(this));

    }

    // Start is called before the first frame update
    void Start()
    {
        this.TransitionState(StateType.Idle);
    }

    public void TransitionState(StateType type)
    {
        if (currentState != null)
            currentState.OnExit();
        currentState = states[type];
        currentState.OnEnter();
    }

    public void test()
    {
        Debug.Log("health = " + this.par.health);
      
        if (this.par.health <= 0)
        {
            if (states.ContainsKey(StateType.Death))
            {
                this.TransitionState(StateType.Death);
            }
            else
            {
                states.Add(StateType.Death, new Dead(this));
                this.TransitionState(StateType.Death);
            }
        }
        else
        {
            if (states.ContainsKey(StateType.Hit))
            {
                this.TransitionState(StateType.Hit);
            }
            else
            {
                this.par.an.Play("shit", 0, 0f);
                states.Add(StateType.Hit, new Hit(this));
                states.Add(StateType.Death, new Dead(this));

            }
        }




        // this.par.an.Play("shit");
        //this.TransitionState(StateType.Hit);
    }

    // Update is called once per frame
    void Update()
    {
     
        this.currentState.OnUpdate();
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireSphere(this.transform.position, 0.7f);
    }
}
