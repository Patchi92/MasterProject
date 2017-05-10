using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

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
                GameObject.Find("Player").GetComponent<PlayerClass>().PickUpGold(30);
                UI.transform.FindChild("Interact").gameObject.SetActive(false);
                Destroy(gameObject);
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
