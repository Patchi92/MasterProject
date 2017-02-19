using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActTest : MonoBehaviour
{

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.F))
        //{
        //    UI.GetComponent<UiSystem>().LockPlayer();
        //    DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 0);
        //    ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 0);
        //}
    }

    public void TestNPC()
    {
        ChoiceSystem.GetComponent<ChoiceSelection>().ResetSystem();

        UI.GetComponent<UiSystem>().LockPlayer();
        DialogSystem.GetComponent<DialogSelection>().StartCoroutine("DialogSystem", 0);
        ChoiceSystem.GetComponent<ChoiceSelection>().StartCoroutine("ChoiceSystem", 0);
    }



}
