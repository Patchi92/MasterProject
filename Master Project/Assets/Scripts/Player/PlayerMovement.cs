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



    private void Awake()
    {
        rBody = this.GetComponent<Rigidbody>();
        inAirCheck = transform.FindChild("GroundCheck").GetComponent<JumpCheck>();
        
    }


    // Use this for initialization
    void Start ()
    {
        speedAccel = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        

        if (Input.GetKey(KeyCode.W))
        {
            if (speedAccel < 0)
            {
                speedAccel = speedAccel * -1;
            }

            frontVel = frontSpeed + speedAccel;
            if (frontVel < speedCap)
            {
                speedAccel += increaseAccel;
            }

            
        }


        if (Input.GetKey(KeyCode.S))
        {
            frontVel = -frontSpeed;

        }


        if (Input.GetKey(KeyCode.D))
        {
            if(speedAccel < 0)
            {
                speedAccel = speedAccel * -1;
            }

            sideVel = sideSpeed + speedAccel;
            if (sideVel < speedCap)
            {
                speedAccel += increaseAccel;
            }
        }


        if (Input.GetKey(KeyCode.A))
        {
            if (speedAccel > 0)
            {
                speedAccel = speedAccel * -1;
            }

            sideVel = -sideSpeed + speedAccel;
            if (sideVel > -speedCap)
            {
                speedAccel -= increaseAccel;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inAirCheck.inAir == false)
            {
                //jumpVel = jumpHeight;
                inAirCheck.inAir = true;
            }
        }

        MovePlayer();
        MoveReset();
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
        frontVel = 0;
        sideVel = 0;
        jumpVel = 0;

       
    }
}
