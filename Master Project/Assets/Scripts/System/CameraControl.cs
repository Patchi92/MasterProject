using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    // Mouse Look Around

    GameObject player;

    Quaternion originalRotation;
    float yRotation;
    public float minimumY;
    public float maximumY;
    public float sensitivityY;

    public bool lookLock;

    // Use this for initialization
    void Start()
    {
        player = gameObject.transform.parent.gameObject;
        

        Cursor.visible = false;
        lookLock = false;
        originalRotation = transform.localRotation;
        yRotation = 0;

    }

    // Update is called once per frame
    void Update()
    {
        lookLock = player.GetComponent<PlayerLookAround>().lookLock;

        if (!lookLock)
        {
            yRotation += Input.GetAxis("Mouse Y") * sensitivityY;
            yRotation = ClampAngle(yRotation, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(yRotation, -Vector3.right);

            transform.localRotation = originalRotation * yQuaternion;
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
