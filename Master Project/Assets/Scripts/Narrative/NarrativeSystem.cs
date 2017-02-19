using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeSystem : MonoBehaviour {

    GameObject UI;
    GameObject DialogSystem;
    GameObject ChoiceSystem;

    void Awake()
    {
        UI = GameObject.Find("UI");
        DialogSystem = UI.transform.FindChild("Dialog").gameObject;
        ChoiceSystem = UI.transform.FindChild("Choice").gameObject;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Narrative(string info)
    {
        ChoiceSystem.GetComponent<ChoiceSelection>().ResetSystem();
        UI.GetComponent<UiSystem>().LockPlayer();

        if(info == "Quest")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 0);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 0);
        }

        if (info == "DogOne")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 1);
        }

        if (info == "DogTwo")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 2);
        }

        if (info == "DogThree")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 3);
        }

        if (info == "Sword")
        {
            DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 4);
            ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 1);
        }

    }

   
}
