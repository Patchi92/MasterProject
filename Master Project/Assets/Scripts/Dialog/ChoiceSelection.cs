using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceSelection : MonoBehaviour {

    // Narrative
    GameObject narrativeSystem;

    // Choice

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
    bool moreChoices;


    // Response

    GameObject response;
    string responseName;

    string choiceResponse;
    string responseOne;
    string responseTwo;
    string responseThree;
    string responseFour;

    float choiceWait;
    float responseWaitOne;
    float responseWaitTwo;
    float responseWaitThree;
    float responseWaitFour;





    void Awake()
    {
        narrativeSystem = GameObject.Find("NarrativeSystem");

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

        response = transform.parent.transform.FindChild("Dialog").transform.FindChild("DialogBox").transform.FindChild("Text").gameObject;
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

                choiceResponse = responseName + ":" + "\n" + "\n" + responseOne;
                choiceWait = responseWaitOne;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedOption = 2;

                Unselected(choiceOptionOne);
                Selected(choiceOptionTwo);
                Unselected(choiceOptionThree);
                Unselected(choiceOptionFour);

                choiceResponse = responseName + ":" + "\n" + "\n" + responseTwo;
                choiceWait = responseWaitTwo;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (moreChoices == true)
                {
                    selectedOption = 3;

                    Unselected(choiceOptionOne);
                    Unselected(choiceOptionTwo);
                    Selected(choiceOptionThree);
                    Unselected(choiceOptionFour);

                    choiceResponse = responseName + ":" + "\n" + "\n" + responseThree;
                    choiceWait = responseWaitThree;
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (moreChoices == true)
                {
                    selectedOption = 4;

                    Unselected(choiceOptionOne);
                    Unselected(choiceOptionTwo);
                    Unselected(choiceOptionThree);
                    Selected(choiceOptionFour);

                    choiceResponse = responseName + ":" + "\n" + "\n" + responseFour;
                    choiceWait = responseWaitFour;
                }
            }

            if(selectedOption == 1 || selectedOption == 2 || selectedOption == 3 || selectedOption == 4)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartCoroutine("ResponseSystem");
                }
            }
            

        }
        else
        {
            choiceBox.SetActive(false);
        }


    }


    IEnumerator ResponseSystem() {

        UI.choice = false;
        response.GetComponent<Text>().text = choiceResponse;
        UI.dialog = true;
        yield return new WaitForSeconds(choiceWait);
        UI.dialog = false;
        UI.GetComponent<UiSystem>().UnlockPlayer();
        narrativeSystem.GetComponent<NarrativeSystem>().NarrativeFeedback(selectedOption);

    }



    void ChoiceSystem(int v)
    {
        Choice c = choices[v];

        responseName = c.Name;

        choiceOptionOneText.GetComponent<Text>().text = c.choice[0];
        choiceOptionTwoText.GetComponent<Text>().text = c.choice[1];
        responseOne = c.response[0];
        responseTwo = c.response[1];
        responseWaitOne = c.wait[0];
        responseWaitTwo = c.wait[1];

        if (c.simpleQuestion == false)
        {
            choiceOptionThree.SetActive(true);
            choiceOptionFour.SetActive(true);
            moreChoices = true;

            choiceOptionThreeText.GetComponent<Text>().text = c.choice[2];
            choiceOptionFourText.GetComponent<Text>().text = c.choice[3];
            responseThree = c.response[2];
            responseFour = c.response[3];
            responseWaitThree = c.wait[2];
            responseWaitFour = c.wait[3];
        } else
        {
            choiceOptionThree.SetActive(false);
            choiceOptionFour.SetActive(false);
            moreChoices = false;
        }


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