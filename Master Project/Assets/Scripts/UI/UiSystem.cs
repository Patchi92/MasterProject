using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSystem : MonoBehaviour {

    public bool dialog;
    public bool choice;

    GameObject player;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Use this for initialization
    void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

	}

    public void LockPlayer()
    {
        player.GetComponent<PlayerMovement>().movementLock = true;
        player.GetComponent<PlayerLookAround>().lookLock = true;
    }

    public void UnlockPlayer()
    {
        player.GetComponent<PlayerMovement>().movementLock = false;
        player.GetComponent<PlayerLookAround>().lookLock = false;
    }


}
