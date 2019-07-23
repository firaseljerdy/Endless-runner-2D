using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    //ACCESS THESE
    public Animator anim;

    public float moveHorizontal_speed;

    public float speedScalar;

    public float theSpeedIncreaseMilestone;

    public float jump_force;

    public GameObject test;

    public LayerMask groundLayer;

    public Transform groundCheckPoint;

    public float groundCheckRadius;

    public float jump_time;

    public gameManager gm;

    public AudioSource jumpSound;

    public AudioSource deathSound;

 

 
    //CANNOT ACCESS THESE
    private Rigidbody2D rb;

    private bool isTouchingGround = false;

    private float jump_time_counter;

    private float speedMilestone_count;

    private float movespeed_store;

    private float speedmilestoneCount;

    private bool stoppedJumping;

    


    // Use this for initialization
    void Start () {

        

        stoppedJumping = true;


        anim = gameObject.GetComponentInChildren<Animator>();

        rb = GetComponent<Rigidbody2D>();

        jump_time_counter = jump_time;

        speedMilestone_count = theSpeedIncreaseMilestone;

        movespeed_store = moveHorizontal_speed;

        speedMilestone_count = speedmilestoneCount;

    }

 

    // Update is called once per frame
    void Update () {

        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        //speed up in function of position
        if (transform.position.x > speedMilestone_count)
        {
            speedMilestone_count += theSpeedIncreaseMilestone;

            theSpeedIncreaseMilestone *= speedScalar;

            moveHorizontal_speed *= speedScalar;

            //limit the speed
            if (moveHorizontal_speed >= 45f)
            {

                moveHorizontal_speed = 45f;

            }

        }


     
        //move the player on the x axis FOREVA
        rb.velocity = new Vector2(moveHorizontal_speed, rb.velocity.y);


        //case to when player jump
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {

            rb.velocity = new Vector2(rb.velocity.x, jump_force);

            stoppedJumping = false;

            jumpSound.Play();

            anim.SetBool("jumping", true);

  
        }
      

        if ((Input.GetKey(KeyCode.Space)) && !stoppedJumping)
        {

            if (jump_time_counter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump_force);

                jump_time_counter -= Time.deltaTime;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {

            jump_time_counter = 0;

            stoppedJumping = true;

        }

        if (isTouchingGround) 
        {
            jump_time_counter = jump_time;


            anim.SetBool("jumping", false);

        }

    }

  
    /*case when player dies*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "restartBox")
        {
           

            gm.RestartGame();

            moveHorizontal_speed = movespeed_store;

            speedmilestoneCount = speedMilestone_count;

            theSpeedIncreaseMilestone = 135;

            deathSound.Play();
            
            

        }


    }
}
