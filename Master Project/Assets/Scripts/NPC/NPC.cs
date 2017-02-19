using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    NarrativeSystem narrative;
    public string dialog;

    GameObject title;
    public bool ableSpeak;


    private void Awake()
    {
        narrative = GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>();
        title = gameObject.transform.GetChild(1).gameObject;

    }

    // Use this for initialization
    void Start () {
        ableSpeak = false;
        title.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
        if(ableSpeak)
        {
            title.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                narrative.Narrative(dialog);
                ableSpeak = false;
            }
        } else
        {
            title.SetActive(false);
        }

	}
}
