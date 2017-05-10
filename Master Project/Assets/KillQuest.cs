using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : MonoBehaviour {

    int kills;
    public int totalKills;

	// Use this for initialization
	void Start () {
        kills = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KillQuestTracker()
    {
        ++kills;

        if(kills == totalKills)
        {
            gameObject.GetComponent<NPC>().dialog = "KillCompleted";
            gameObject.transform.FindChild("SpeakArea").gameObject.SetActive(true);
            PlayerPrefs.SetInt("Quests", PlayerPrefs.GetInt("Quests") + 1);
        }
    }
}
