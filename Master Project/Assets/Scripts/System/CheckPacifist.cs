using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPacifist : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetString("PlayerType") != "Pacifist")
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
