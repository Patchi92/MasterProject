using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetString("PlayerType") != "Killer")
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
