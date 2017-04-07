using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    // Movement/Physics
    Rigidbody rBody;
    public float frontSpeed;
    public float sideSpeed;
    public float jumpHeight;
    //public float jumpGravity;

    [SerializeField]
    float speedAccel;
    public float increaseAccel;
    public float speedCap;

    float frontVel;
    float sideVel;
    float jumpVel;

    JumpCheck inAirCheck;
    public bool movementLock;


    // Animation
    Animator playerCamera;



    private void Awake()
    {
        rBody = this.GetComponent<Rigidbody>();
        playerCamera = transform.FindChild("Player Camera").GetComponent<Animator>();
        inAirCheck = transform.FindChild("GroundCheck").GetComponent<JumpCheck>();
        
    }


    // Use this for initialization
    void Start ()
    {
        gameObject.name = "Player";
        movementLock = false;
        speedAccel = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!movementLock)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speedCap = 100;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speedCap = 5;
            }


            if (Input.GetKey(KeyCode.W))
            {

                playerCamera.SetBool("isWalking", true);
                sideVel = 0;

                if (speedAccel < 0)
                {
                    speedAccel = speedAccel * -1;
                }

                frontVel = frontSpeed + speedAccel;
                if (frontVel < speedCap)
                {
                    playerCamera.speed += 0.001f;
                    speedAccel += increaseAccel;
                }


            }




            if (Input.GetKey(KeyCode.S))
            {
                sideVel = 0;
                playerCamera.speed = 1;
                playerCamera.SetBool("isWalking", true);
                frontVel = -frontSpeed;

            }


            if (Input.GetKey(KeyCode.D))
            {
                playerCamera.SetBool("isWalking", true);
                frontVel = 0;

                if (speedAccel < 0)
                {
                    speedAccel = speedAccel * -1;
                }

                sideVel = sideSpeed + speedAccel;
                if (sideVel < speedCap)
                {
                    playerCamera.speed += 0.001f;
                    speedAccel += increaseAccel;
                }
            }


            if (Input.GetKey(KeyCode.A))
            {
                playerCamera.SetBool("isWalking", true);
                frontVel = 0;

                if (speedAccel > 0)
                {
                    speedAccel = speedAccel * -1;
                }

                sideVel = -sideSpeed + speedAccel;
                if (sideVel > -speedCap)
                {
                    playerCamera.speed += 0.001f;
                    speedAccel -= increaseAccel;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerCamera.SetBool("isWalking", true);

                if (inAirCheck.inAir == false)
                {
                    //jumpVel = jumpHeight;
                    inAirCheck.inAir = true;
                }
            }

        }

        MovePlayer();

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) || movementLock == true)
        {
            MoveReset();
        }
        
    }

    void MovePlayer()
    {
        rBody.velocity = new Vector3(sideVel, jumpVel, frontVel);
        rBody.velocity = transform.TransformDirection(rBody.velocity);

        if(rBody.velocity.x == 0 && rBody.velocity.z == 0)
        {
            speedAccel = 0;
        }

    }

    void MoveReset()
    {
        playerCamera.SetBool("isWalking", false);

        playerCamera.speed = 1;
        frontVel = 0;
        sideVel = 0;
        jumpVel = 0;

       
    }
}
