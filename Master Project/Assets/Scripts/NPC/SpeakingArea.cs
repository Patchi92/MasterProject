using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakingArea : MonoBehaviour {

    NPC NPC;

    private void Awake()
    {
        NPC = gameObject.GetComponentInParent<NPC>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            NPC.ableSpeak = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            NPC.ableSpeak = false;
        }
    }
}
