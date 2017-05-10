using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterThreeIntro : MonoBehaviour {

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
            if (PlayerPrefs.GetString("PlayerType") == "Hero")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterThreeIntroHero");
            }

            if (PlayerPrefs.GetString("PlayerType") == "Killer")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterThreeIntroKiller");
            }

            if (PlayerPrefs.GetString("PlayerType") == "Pacifist")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterThreeIntroPacifist");
            }

            Destroy(gameObject);
        }
    }
}
