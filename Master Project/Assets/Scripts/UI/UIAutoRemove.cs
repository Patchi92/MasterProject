using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAutoRemove : MonoBehaviour {

    public GameObject objectHide;
    public GameObject objectUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(!objectUI.activeSelf)
        {
            objectHide.SetActive(false);
        } else {
            objectHide.SetActive(true);
        }



	}
}
