using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEnterCave : MonoBehaviour {


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
            GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("Cave");
            Destroy(gameObject);
        }
    }
}
