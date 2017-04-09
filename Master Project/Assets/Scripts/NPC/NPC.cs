using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public bool repeatDialog;

    GameObject UI;

    NarrativeSystem narrative;
    public string dialog;

    Ray chargeRay;
    RaycastHit chargeHit;

    GameObject title;
    public bool ableSpeak;


    private void Awake()
    {
        UI = GameObject.Find("UI");
        narrative = GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>();
        title = gameObject.transform.GetChild(1).gameObject;

    }

    // Use this for initialization
    void Start () {
        ableSpeak = false;
        title.SetActive(false);
        title.GetComponent<TextMesh>().text = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(ableSpeak)
        {
            //title.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {

                chargeRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(chargeRay, out chargeHit))
                {
                    if (chargeHit.transform.tag == "NPC")
                    {
                        narrative.Narrative(dialog);
   
                        if(!repeatDialog)
                        {
                            ableSpeak = false;
                            UI.transform.FindChild("Interact").gameObject.SetActive(false);
                            gameObject.transform.FindChild("SpeakArea").gameObject.SetActive(false);
                        }
                       
                    }
                }


               
            }
        } else
        {
            title.SetActive(false);
        }

	}
}
