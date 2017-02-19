using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour {

    public bool inAir;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            inAir = false;
        } 
    }

}
