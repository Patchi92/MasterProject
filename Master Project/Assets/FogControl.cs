using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogControl : MonoBehaviour {

    bool fog;

	// Use this for initialization
	void Start () {
        fog = true;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(fog == true)
            {
                RenderSettings.fog = false;
                fog = false;
            } else
            {
                RenderSettings.fog = true;
                fog = true;
            }
        }
    }
}
