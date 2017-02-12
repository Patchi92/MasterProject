using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSelection : MonoBehaviour {

    public Choice[] choices;
    UiSystem UI;
    GameObject choiceBox;
    GameObject choiceOptionOne;
    GameObject choiceOptionTwo;
    GameObject choiceOptionThree;
    GameObject choiceOptionFour;


    void Awake()
    {
        UI = transform.parent.gameObject.GetComponent<UiSystem>();
        choiceBox = transform.FindChild("ChoiceBox").gameObject;
        choiceOptionOne = choiceBox.transform.FindChild("Option1").transform.FindChild("Text").gameObject;
        choiceOptionTwo = choiceBox.transform.FindChild("Option2").transform.FindChild("Text").gameObject;
        choiceOptionThree = choiceBox.transform.FindChild("Option3").transform.FindChild("Text").gameObject;
        choiceOptionFour = choiceBox.transform.FindChild("Option4").transform.FindChild("Text").gameObject;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (UI.choice)
        {
            choiceBox.SetActive(true);

            // Indsæt keypress her!

        }
        else
        {
            choiceBox.SetActive(false);
        }


  

    }

    void ChoiceSystem(int v)
    {
        Choice c = choices[v];

        choiceOptionOne.GetComponent<Text>().text = c.Text[0];
        choiceOptionTwo.GetComponent<Text>().text = c.Text[1];
        choiceOptionThree.GetComponent<Text>().text = c.Text[2];
        choiceOptionFour.GetComponent<Text>().text = c.Text[3];
    }
}