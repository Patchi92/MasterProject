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

    GameObject choiceOptionOneText;
    GameObject choiceOptionTwoText;
    GameObject choiceOptionThreeText;
    GameObject choiceOptionFourText;

    int selectedOption;


    void Awake()
    {
        UI = transform.parent.gameObject.GetComponent<UiSystem>();
        choiceBox = transform.FindChild("ChoiceBox").gameObject;
        choiceOptionOne = choiceBox.transform.FindChild("Option1").gameObject;
        choiceOptionTwo = choiceBox.transform.FindChild("Option2").gameObject;
        choiceOptionThree = choiceBox.transform.FindChild("Option3").gameObject;
        choiceOptionFour = choiceBox.transform.FindChild("Option4").gameObject;

        choiceOptionOneText = choiceOptionOne.transform.FindChild("Text").gameObject;
        choiceOptionTwoText = choiceOptionTwo.transform.FindChild("Text").gameObject;
        choiceOptionThreeText = choiceOptionThree.transform.FindChild("Text").gameObject;
        choiceOptionFourText = choiceOptionFour.transform.FindChild("Text").gameObject;
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

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                selectedOption = 1;

                Selected(choiceOptionOne);
                Unselected(choiceOptionTwo);
                Unselected(choiceOptionThree);
                Unselected(choiceOptionFour);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedOption = 2;

                Unselected(choiceOptionOne);
                Selected(choiceOptionTwo);
                Unselected(choiceOptionThree);
                Unselected(choiceOptionFour);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                selectedOption = 3;

                Unselected(choiceOptionOne);
                Unselected(choiceOptionTwo);
                Selected(choiceOptionThree);
                Unselected(choiceOptionFour);
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                selectedOption = 4;

                Unselected(choiceOptionOne);
                Unselected(choiceOptionTwo);
                Unselected(choiceOptionThree);
                Selected(choiceOptionFour);
            }

            if(selectedOption == 1 || selectedOption == 2 || selectedOption == 3 || selectedOption == 4)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    UI.choice = false;
                    UI.GetComponent<UiSystem>().UnlockPlayer();
                }
            }
            

        }
        else
        {
            choiceBox.SetActive(false);
        }


  

    }

    void ChoiceSystem(int v)
    {
        Choice c = choices[v];

        choiceOptionOneText.GetComponent<Text>().text = c.Text[0];
        choiceOptionTwoText.GetComponent<Text>().text = c.Text[1];
        choiceOptionThreeText.GetComponent<Text>().text = c.Text[2];
        choiceOptionFourText.GetComponent<Text>().text = c.Text[3];
    }

    void Selected(GameObject o)
    {
        o.GetComponent<RawImage>().color = Color.yellow; //new Color(255, 255, 150, 255);
    }

    void Unselected(GameObject o)
    {
        o.GetComponent<RawImage>().color = Color.white; //new Color(255, 255, 255, 255);
    }

    void Unavalible(GameObject o)
    {
        o.GetComponent<RawImage>().color = Color.grey;  //new Color(255, 255, 255, 100);
    }

   public void ResetSystem()
    {
        selectedOption = 0;

        Unselected(choiceOptionOne);
        Unselected(choiceOptionTwo);
        Unselected(choiceOptionThree);
        Unselected(choiceOptionFour);
    }
}