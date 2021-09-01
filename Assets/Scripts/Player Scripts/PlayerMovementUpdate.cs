using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementUpdate : MonoBehaviour
{

    //int var


    public Vector2 moveSpeed;
    public float normalSpeed = 3.0f;
    public float dashing = 5.0f;
    public float jumpForce = 300f;
    public float dashForceY = 15f;
    public float dashForceSlowY = 13f;

    private Animator animator;
    private Rigidbody2D _rigidbody2D;


    //for flip
    private bool facingRight = true;

    //for move
    public float horizontalMovement;
    public float VerticalMovement;

    //for jump 
    public Transform groundCheck;
    public float checkRadius;
    private bool isGrounded;
    public LayerMask whatIsGround;
    private bool isJumping = false;

    //for double jump
    private int extraJumps;
    public int extraJumpsValue;


    //for dash
    private int extraDash;
    public int extraDashValue;
    public GameObject dashEffect;




    void Start()
    {
   	 animator = GetComponent<Animator>();
	_rigidbody2D = GetComponent<Rigidbody2D>();

        extraJumps = extraJumpsValue;
        extraDash = extraDashValue;
        moveSpeed = new Vector2(3f, 0f);
    }

    void FixedUpdate()
    {
        float characterSpeed = Mathf.Abs(_rigidbody2D.velocity.x);
        animator.SetFloat("Speed", characterSpeed);
		
        animator.SetBool("isGrounded", isGrounded);

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed.x;
        VerticalMovement = Input.GetAxis("Vertical") * moveSpeed.y;

           _rigidbody2D.velocity = new Vector2(horizontalMovement, _rigidbody2D.velocity.y);



        if (facingRight == false && horizontalMovement > 0)
        {
            Flip();
        }
        else if (facingRight== true && horizontalMovement <0)
        {
            Flip();
        }

        if(isGrounded == true)
        {
            extraJumps = 1;
            extraDash = 1;
            animator.SetBool("isJumping", false);
        }
        else
        {

            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps>0)
        {  
             animator.SetBool("isJumping", true);
            FindObjectOfType<AudioManagerScript>().Play("Jump_Sound");
            isJumping = true;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(new Vector2(0, jumpForce));
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
           FindObjectOfType<AudioManagerScript>().Play("Jump_Sound");
            _rigidbody2D.velocity = Vector2.up * jumpForce;
        } 

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //x
            moveSpeed.x = dashing;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            //x
            moveSpeed.x = normalSpeed;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
       
            if (extraDash >= 1)
                {
                FindObjectOfType<AudioManagerScript>().Play("slash_Sound");
                StartCoroutine("DashMove");
                GameObject dash = Instantiate(dashEffect, transform.position, Quaternion.identity);
                dash.transform.parent = transform;
                Destroy(dash, 1);
                --extraDash;
                }
        }
        if(Input.GetKeyDown(KeyCode.X) )
        {
            if (extraDash >= 1)
            {
                 FindObjectOfType<AudioManagerScript>().Play("slash_Sound");
                GameObject dash = Instantiate(dashEffect, transform.position, Quaternion.identity);
                dash.transform.parent = transform;
                Destroy(dash, 1);

                StartCoroutine("DashVertical");
               
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    IEnumerator DashMove()
    {
        //movespeed.x
        
        _rigidbody2D.velocity = Vector2.zero;
        moveSpeed.x += 10;

        _rigidbody2D.gravityScale = 0;
        yield return new WaitForSeconds(0.3f);
        _rigidbody2D.gravityScale = 1;

        moveSpeed.x -= 10;
    }
    IEnumerator DashVertical()
    {
        --extraDash;
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.velocity += Vector2.up * dashForceY;
        _rigidbody2D.gravityScale = 0;
        yield return new WaitForSeconds(0.3f);
       // _rigidbody2D.gravityScale = 0;
      //  yield return new WaitForSeconds(0.1f);
        _rigidbody2D.gravityScale = 1;
        _rigidbody2D.velocity -= Vector2.up *dashForceSlowY;

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<SliceCollide>())
        {
            extraDash++;
        }
    }


}
