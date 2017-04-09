using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour {

    // Mouse Look Around

    Quaternion originalRotation;
    float xRotation;
    float yRotation;
    float minimumX;
    float maximumX;
    public float minimumY;
    public float maximumY;
    public float sensitivityX;
    public float sensitivityY;

    public bool lookLock;

    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        lookLock = false;
        originalRotation = transform.localRotation;
        xRotation = 0;
        yRotation = 0;

        minimumX = -360f;
        maximumX = 360f;
    }
	
	// Update is called once per frame
	void Update () {


        if(!lookLock)
        {
            xRotation += Input.GetAxis("Mouse X") * sensitivityX;
            yRotation += Input.GetAxis("Mouse Y") * sensitivityY;
            xRotation = ClampAngle(xRotation, minimumX, maximumX);
            yRotation = ClampAngle(yRotation, minimumY, maximumY);
            Quaternion xQuaternion = Quaternion.AngleAxis(xRotation, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(yRotation, -Vector3.right);

            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
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
