using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VersionCheckSimpleMix : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("Version") == "Complex")
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
