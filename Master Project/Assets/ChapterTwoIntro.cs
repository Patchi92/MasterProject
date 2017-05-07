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
            }

            if (PlayerPrefs.GetString("PlayerType") == "Killer")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterTwoIntroKiller");
            }

            if (PlayerPrefs.GetString("PlayerType") == "Pacifist")
            {
                GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().Narrative("ChapterTwoIntroPacifist");
            }

            Destroy(gameObject);
        }
    }

}
