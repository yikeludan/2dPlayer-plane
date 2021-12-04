using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    private float moveSpeed = 6f;

    private Vector2 vec2 = new Vector2(0, 0);

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

    private AnimatorStateInfo animatorInfostateinfo;

    private bool isRun = false;

    private float offsetX = 0;

    private int attackCount;

    private bool isLightAttack2 = false;

    private bool isLightAttack3 = false;

    private bool isShift;

    private float shiftSpeed;

    public FSM fSM;

    private bool isTrrghtIsAttack = false;

    public ShakeCamera shakeCamera;

    private void Awake()
    {
        this.InitComponet();
    }


    void InitComponet()
    {
        this._rigidbody2D = this.GetComponent<Rigidbody2D>();
        this._animator = this.GetComponent<Animator>();
    
        attackCount = 0;
        shiftSpeed = 15;
    }

    void InputRunFloat()
    {
        x = Input.GetAxis("Horizontal");

    }

    void InputGetKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPress = true;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            isShift = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isAttack = true;
            if (isLightAttack2)
            {
                isLightAttack3 = true;
            }
            if (attackCount == 1)
            {
                isLightAttack2 = true;
            }
            if (attackCount == 0)
            {
                attackCount += 1;
            }
        }
    }

    void SwitchAttackAni()
    {
        animatorInfostateinfo = this._animator.GetCurrentAnimatorStateInfo(0);
        bool LightAttack1 = animatorInfostateinfo.IsName("LightAttack1");
        bool LightAttack2 = animatorInfostateinfo.IsName("LightAttack2");
        bool LightAttack3 = animatorInfostateinfo.IsName("LightAttack3");
        bool shift = animatorInfostateinfo.IsName("shift");
        if (shift)
        {
            if (animatorInfostateinfo.normalizedTime >= 1.0f)
            {
                isShift = false;
                shiftSpeed = 15f;
            }
            else
            {

                shiftSpeed = Mathf.Lerp(shiftSpeed, 0, 1f * Time.fixedDeltaTime);
                /*if (this.transform.right.normalized.x > 0)
                {
                    shiftSpeed = -shiftSpeed;
                    print("shiftSpeed = "+shiftSpeed);
                }*/
                this._rigidbody2D.velocity = new Vector2(-this.transform.right.normalized.x * shiftSpeed, this._rigidbody2D.velocity.y);
            }
        }

        if (LightAttack3)
        {
            if (animatorInfostateinfo.normalizedTime >= 0.7f)
            {
                attackCount = 0;
                isAttack = false;
                isLightAttack3 = false;
                isLightAttack2 = false;
                isTrrghtIsAttack = false;
            }
            else
            {
                isTrrghtIsAttack = true;
            }
        }

        if (LightAttack2)
        {
            if (animatorInfostateinfo.normalizedTime >= 0.7f)
            {
                if (isLightAttack3)
                {
                    attackCount = 3;
                }
                else
                {
                    attackCount = 0;
                    isAttack = false;
                    isLightAttack3 = false;
                    isLightAttack2 = false;
                    isTrrghtIsAttack = false;
                }
            }
            else
            {
                isTrrghtIsAttack = true;
            }
        }
        if (LightAttack1)
        {
            if (animatorInfostateinfo.normalizedTime >= 0.75f)
            {

                if (attackCount != 0)
                {
                    if (isLightAttack2)
                    {
                        if (attackCount == 1)
                        {
                            attackCount += 1;
                        }
                    }
                    else
                    {
                        attackCount = 0;
                        isAttack = false;
                        isLightAttack2 = false;
                        isTrrghtIsAttack = false;
                    }

                }
            }
            else
            {
                //offsetX = Mathf.Lerp(offsetX, 10, 2 * Time.deltaTime);
                //offsetX += Time.deltaTime * 2f;
                isTrrghtIsAttack = true;

            }
            //this._rigidbody2D.velocity = new Vector2(offsetX, this._rigidbody2D.velocity.y);
        }
    }


    void Start()
    {

    }

    // Update is called once per frame


    void checkIsGround()
    {
        this.isGround = Physics2D.OverlapCircle(this.groundCheck.position, 0.5f, ground);
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
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
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

        this._animator.SetInteger("attack", this.attackCount);
        this._animator.SetBool("run", this.isRun);
        this._animator.SetBool("isShift", isShift);
        //this._animator.SetBool("jump",isGround == false);
    }

    void Move()
    {
        if (isAttack)
        {
            this._rigidbody2D.velocity = Vector2.zero;
            return;
        }
        if (!isAttack && !isShift)
        {
            this._rigidbody2D.velocity = new Vector2(this.moveSpeed * x, this._rigidbody2D.velocity.y);
        }
    }

    void Update()
    {
        this.InputGetKey();

        this.InputRunFloat();
        this.checkIsRun();
        this.checkIsGround();

        this.turnRound();
        this.showAni();


    }

    private void FixedUpdate()
    {
        this.SwitchAttackAni();
        this.Move();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        print("other.gameObject.name = "+other.gameObject.name);
        if (other.gameObject.name.Equals("sAreg"))
        {
            // print("other.gameObject.name = "+other.gameObject.name);
            return;
        }
        
        if (other.gameObject.name.Equals("skeleton"))
        {
            // print("other.gameObject.name = "+other.gameObject.name);
            // this.fSM.test();
            
            animatorInfostateinfo = this._animator.GetCurrentAnimatorStateInfo(0);
            bool LightAttack1 = animatorInfostateinfo.IsName("LightAttack1");
            bool LightAttack2 = animatorInfostateinfo.IsName("LightAttack2");
            bool LightAttack3 = animatorInfostateinfo.IsName("LightAttack3");
            if (LightAttack1 || LightAttack2 || LightAttack3)
            {
                this.shakeCamera.isshakeCamera = true;
                this.fSM.test();
            }


        }


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // if(other.gameObject.name.Equals("skeleton")){
        //     animatorInfostateinfo = this._animator.GetCurrentAnimatorStateInfo(0);
        //     bool LightAttack1 = animatorInfostateinfo.IsName("LightAttack1");
        //     bool LightAttack2 = animatorInfostateinfo.IsName("LightAttack2");
        //     bool LightAttack3 = animatorInfostateinfo.IsName("LightAttack3");
        //     if (LightAttack1 || LightAttack2 || LightAttack3)
        //     {
        //         print("player12");
        //         //this.fSM.test();
        //     }
        // }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        print("playerc");
    }


}
