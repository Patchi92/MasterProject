using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterOneEnd : MonoBehaviour {

    public GameObject question;
    GameObject player;
    public GameObject nextPos;

    public bool exitChapter;

	// Use this for initialization
	void Start () {
        exitChapter = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (exitChapter)
            {
                player = GameObject.Find("Player");

                question.SetActive(true);
                player.transform.position = nextPos.transform.position;
                player.SetActive(false);
                Destroy(gameObject);
            } else
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("Gate");
            }
        }
    }
}
