using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControllerBak : MonoBehaviour
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

    private void Awake()
    {
        this._rigidbody2D = this.GetComponent<Rigidbody2D>();
        this._animator = this.GetComponent<Animator>();
      //  this.vec2.y = this._rigidbody2D.velocity.y;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stateinfo  = this._animator.GetCurrentAnimatorStateInfo(0);   
        bool attack = stateinfo.IsName("attack");
        if(attack)
        {
            if(stateinfo.normalizedTime < 1.0f)
            {
                //正在播放
                print("start");
            }
            else
            {
                //播放结束
                print("end");
                isAttack = false;
            }
	
        }

        bool playingJump = stateinfo.IsName("jump");
         x = Input.GetAxis("Horizontal");
         if (Input.GetKeyDown(KeyCode.Space))
         {
             jumpPress = true;
         }
         if (Input.GetMouseButton(0))
         {
             isAttack = true;
         }
         
         
    }

    private void FixedUpdate()
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

        if (x < 0)
        {
            isTurnRoll = true;
        }

        if (x > 0)
        {
            isTurnRoll = false;
        }

        vec2.x = x;
       
        vec2 = vec2 * this.moveSpeed;
      
        this._animator.SetBool("attack",this.isAttack);

        this._animator.SetBool("run",this._rigidbody2D.velocity.magnitude != 0);
        //this._rigidbody2D.velocity = Vector2.Lerp(this._rigidbody2D.velocity,vec2,this.moveSpeed);
        this._rigidbody2D.velocity = new Vector2(this.moveSpeed * x, this._rigidbody2D.velocity.y);
        
        
        
        if (isGround && jumpPress)
        {
            
            jumpForce = 25f;
            this._rigidbody2D.velocity = new Vector2(this._rigidbody2D.velocity.x, jumpForce);
            jumpPress = false;
        }
        this._animator.SetBool("jump",isGround == false);

        if (this.isTurnRoll)
        {
            this.transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            
            this.transform.rotation = Quaternion.Euler(0,0,0);

        }

       




    }
}
