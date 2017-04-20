using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour {

    // Mouse Look Around

    Quaternion originalRotation;
    float xRotation;
    float minimumX;
    float maximumX;
    public float sensitivityX;

    public bool lookLock;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        lookLock = false;
        originalRotation = transform.localRotation;
        xRotation = 0;

        minimumX = -360f;
        maximumX = 360f;
    }
	
	// Update is called once per frame
	void Update () {


        if(!lookLock)
        {
            xRotation += Input.GetAxis("Mouse X") * sensitivityX;
            xRotation = ClampAngle(xRotation, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(xRotation, Vector3.up);

            transform.localRotation = originalRotation * xQuaternion; 
        }
        
        

    }


    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
         angle += 360F;
        if (angle > 360F)
         angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

  
}
