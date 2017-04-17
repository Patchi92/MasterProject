﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {

        if (other.tag == "EnemyMelee")
        {
            other.GetComponent<EnemyMelee>().ResetNPC();
        }

        if (other.tag == "EnemyRanged")
        {
            other.GetComponent<EnemyRanged>().ResetNPC();
        }
    }

}
