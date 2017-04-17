using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionCheckComplex : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("Version") == "Simple" || PlayerPrefs.GetString("Version") == "Mixed")
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
