using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float moveSpeed = 10f;

    private Vector2 vec2 = new Vector2(0,0);

    private Rigidbody2D _rigidbody2D;

    private Animator _animator;

    public Transform groundCheck;

    public LayerMask ground;

    private bool isGround;

    private float t = 0;

    private float x = 0;

    private bool isTurnRoll = false;

    private bool jumpPress;
    private float jumpForce;

    private bool isAttack;

    private AnimatorStateInfo stateinfo;

    private bool isRun= false;

    private float offsetX = 0;

    

    private void Awake()
    {
        this.InitComponet();
    }


    void InitComponet()
    {
        this._rigidbody2D = this.GetComponent<Rigidbody2D>();
        this._animator = this.GetComponent<Animator>();
    }

    void InputRunFloat()
    {
        x = Input.GetAxis("Horizontal");
        if (isAttack)
        {
            x = 0;
        }
    }

    void InputGetKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPress = true;
        }
        if (Input.GetMouseButton(0))
        {
            isAttack = true;
        }
    }

   

    void SwitchAttackAni()
    {
        stateinfo  = this._animator.GetCurrentAnimatorStateInfo(0);   
        bool attack = stateinfo.IsName("attack");
        if(attack)
        {
            if(stateinfo.normalizedTime >= 1.0f)
            {
                //正在播放
                isAttack = false;
                offsetX = 0;
            }
            else
            {
                
                offsetX = Mathf.Lerp(offsetX, 10, 10 * Time.deltaTime);
                //offsetX += Time.deltaTime * 2f;
              
            }
            this._rigidbody2D.velocity = new Vector2(offsetX, this._rigidbody2D.velocity.y);
        }
    }
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.InputRunFloat();
        this.InputGetKey();
    }

    void checkIsGround()
    {
        this.isGround = Physics2D.OverlapCircle(this.groundCheck.position, 0.1f, ground);
        if (this.isGround)
        {
            this._rigidbody2D.gravityScale = 0;
        }
        else
        {
            this._rigidbody2D.gravityScale = 9.8f;

        }
    }

    void checkIsRun()
    {
        if (this._rigidbody2D.velocity.magnitude > 0)
        {
            isRun = true;
        }
        else
        {
            isRun = false;
        }
    }

    void turnRound()
    {
        if (x < 0)
        {
            isTurnRoll = true;
        }

        if (x > 0)
        {
            isTurnRoll = false;
        }
        if (this.isTurnRoll)
        {
            this.transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    void Jump()
    {
        if (isGround && jumpPress)
        {
            
            jumpForce = 25f;
            this._rigidbody2D.velocity = new Vector2(this._rigidbody2D.velocity.x, jumpForce);
            jumpPress = false;
        }
    }

   
    void showAni()
    {
        
        this._animator.SetBool("attack",this.isAttack);
        this._animator.SetBool("run",this.isRun);
        this._animator.SetBool("jump",isGround == false);
    }

    void Move()
    {
        if (isAttack)
        {
            return;
        }

        /*vec2.x = x;
        vec2 = vec2 * this.moveSpeed;*/
        //this._rigidbody2D.velocity = Vector2.Lerp(this._rigidbody2D.velocity,vec2,this.moveSpeed);
        this._rigidbody2D.velocity = new Vector2(this.moveSpeed * x, this._rigidbody2D.velocity.y);

    }

    private void FixedUpdate()
    {

        this.checkIsGround();
        this.SwitchAttackAni(); 

        this.checkIsRun();
        this.turnRound();

        this.Jump();
        this.showAni();

        this.Move();

    }
}
