using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuestCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        GameObject.Find("Peasent - Kill Quest").GetComponent<KillQuest>().KillQuestTracker();
    }
}
