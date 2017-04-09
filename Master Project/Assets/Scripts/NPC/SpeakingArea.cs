using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakingArea : MonoBehaviour {

    NPC NPC;
    GameObject UI;

    private void Awake()
    {
        NPC = gameObject.GetComponentInParent<NPC>();
        UI = GameObject.Find("UI");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NPC.ableSpeak = true;
            UI.transform.FindChild("Interact").gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            NPC.ableSpeak = false;
            UI.transform.FindChild("Interact").gameObject.SetActive(false);
        }
    }
}
