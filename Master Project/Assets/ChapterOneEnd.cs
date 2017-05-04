using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterOneEnd : MonoBehaviour {

    public GameObject question;
    GameObject player;
    public GameObject nextPos;

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
            player = GameObject.Find("Player");

            question.SetActive(true);
            player.transform.position = nextPos.transform.position;
            player.SetActive(false);
            Destroy(gameObject);
        }
    }
}
