using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource jumpSound;


    [HideInInspector] public float runSpeed, movement2D, jumpSoundPitchValue;
    [HideInInspector] public Rigidbody2D rb;

    [HideInInspector] public bool grounded, speedTrigger, doubleJumped, jumpRequest, onEarth;

    public bool onFloater;
    public bool UseStartLevelPos;

    private float jumpForce;

    public Animator playerAnimation;

    public GameObject gameController;

    public Joystick joystick;


    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatISGround;
    public LayerMask whatISEarth;
    public LayerMask whatISFloater;


    public GameObject platformYouAreOn;






    void Start()
    {
        if (UseStartLevelPos)
        {
            transform.position = new Vector3(0, -2, 0);

        }

        runSpeed = 3.8f;
        jumpForce = 11.11f;
        rb = GetComponent<Rigidbody2D>();

    }
    void FixedUpdate()
    {
        if (rb.velocity.y < 0 && doubleJumped)
        {
            rb.gravityScale = 3.25f;


        }
        else
        {
            rb.gravityScale = 2.65f;

        }


        grounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatISGround);

        onEarth = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatISEarth);

        onFloater = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatISFloater);

        if (onFloater && platformYouAreOn != null)
        {

            transform.parent = platformYouAreOn.transform;

        }
        if (onEarth || !grounded)
        {
            transform.parent = null;
        }






        if (GetComponent<PlayerStats>().health > 0 && gameController.GetComponent<GameControllerScript>().youWon == false)
        {
            transform.position = new Vector2(transform.position.x + movement2D, transform.position.y);

        }
        if (jumpRequest)
        {
            Jump();

        }




    }
    void Update()
    {


        if (onFloater && platformYouAreOn != null)
        {

            if (platformYouAreOn.GetComponent<PlatformMovement>().targetToGo == platformYouAreOn.GetComponent<PlatformMovement>().target1)
            {
                if (movement2D > 0)
                {
                    runSpeed = 4.8f;

                }
                else if (movement2D < 0)
                {
                    runSpeed = 2.8f;

                }

            }

            else if (platformYouAreOn.GetComponent<PlatformMovement>().targetToGo == platformYouAreOn.GetComponent<PlatformMovement>().target2)
            {
                if (movement2D > 0)
                {
                    runSpeed = 2.8f;

                }
                else if (movement2D < 0)
                {
                    runSpeed = 4.8f;

                }

            }


        }
        else
        {
            runSpeed = 3.8f;

        }





        // jumpForce = 13.8f;


        movement2D = Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime;



        if (GetComponent<PlayerStats>().health > 0 && gameController.GetComponent<GameControllerScript>().youWon == false && Mathf.Abs(joystick.Horizontal) > 0.1f)
        {


            if (joystick.Horizontal > 0.7f)
            {
                movement2D = runSpeed * Time.fixedDeltaTime;

            }
            else if (joystick.Horizontal < -0.7f)

            {
                movement2D = -runSpeed * Time.fixedDeltaTime;


            }
            else
            {
                movement2D = runSpeed * joystick.Horizontal * Time.fixedDeltaTime;

            }





            // Debug.Log( joystick.Horizontal);
            //   Debug.Log(movement2D);



        }




        if (GetComponent<PlayerStats>().health <= 0)
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<PolygonCollider2D>().enabled = false;

        }



        if (Input.GetKeyDown(KeyCode.Z))
        {
            JumpRequest();

        }




        if (movement2D < -0.0f || movement2D > 0.0f)
        {
            speedTrigger = true;
            if (movement2D > 0.0f)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
        }
        else
        {
            speedTrigger = false;

        }


        playerAnimation.SetBool("SpeedTrigger", speedTrigger);

        if (grounded)
        {
            playerAnimation.SetTrigger("Grounded");
            doubleJumped = false;

        }
        else
        {


            playerAnimation.SetTrigger("Jumping");

        }

        if (onEarth)
        {
            // transform.parent = null;
            //onFloater = false;

        }

    }


    public void JumpRequest()
    {
        jumpRequest = true;

    }

    private void Jump()
    {

        if (grounded)

        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundPitchValue= 1.8f;
            jumpSound.pitch = jumpSoundPitchValue;
            jumpSound.Play();
          //  jumpSound = GetComponent<AudioSource>();
                        

        }
        else if (!grounded && !doubleJumped)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce * 0.75f);
            jumpSound.pitch = (jumpSoundPitchValue*1.07f) + 0.17f;

            jumpSound.Play();

            doubleJumped = true;

        }

        jumpRequest = false;


    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floater")
        {
            platformYouAreOn = other.gameObject;

        }

        if (other.gameObject.tag == "Floater")
        {

            //transform.parent = other.transform;
            // onFloater = true;

        }

        if (other.gameObject.tag == "Ground")
        {
            //  transform.parent = null;
            //  onFloater = false;
        }

    }



    /* MANTER COMENTADO
        void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.tag == "Floater" && grounded)
            {

                transform.parent = other.transform;
                onFloater = true;

            }
           else
            {
                transform.parent = null;
                onFloater = false;
            }

        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "Ground")
            {
                transform.parent = null;
                onFloater = false;
            }
        }
        */





}
