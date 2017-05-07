using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindQuestTracker : MonoBehaviour {

    GameObject UI;

    private void Awake()
    {
        UI = GameObject.Find("UI");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.transform.FindChild("Interact").gameObject.SetActive(true);

        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.Find("Peasent - Find Quest").GetComponent<FindQuest>().FindQuestTracker();
                UI.transform.FindChild("Interact").gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UI.transform.FindChild("Interact").gameObject.SetActive(false);
        }
    }
}
