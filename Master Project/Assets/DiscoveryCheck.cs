using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("PlayerDiscoveryPoints", PlayerPrefs.GetInt("PlayerDiscoveryPoints") + 1);
            Destroy(gameObject);
        }


    }
}
