using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterTwoIntro : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.GetString("PlayerType") == "Hero")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterTwoIntroHero");
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().unlockPlayerType = true;
            }

            if (PlayerPrefs.GetString("PlayerType") == "Killer")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterTwoIntroKiller");
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().unlockPlayerType = true;
            }

            if (PlayerPrefs.GetString("PlayerType") == "Pacifist")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterTwoIntroPacifist");
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().unlockPlayerType = true;
            }

           

            Destroy(gameObject);
        }
    }

}
