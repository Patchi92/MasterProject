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

    GameObject choiceOptionOneText;
    GameObject choiceOptionTwoText;
    GameObject choiceOptionThreeText;

    int selectedOption;
    bool moreChoices;


    // Response

    GameObject response;
    string responseName;

    string choiceResponse;
    string responseOne;
    string responseTwo;
    string responseThree;

    float choiceWait;
    float responseWaitOne;
    float responseWaitTwo;
    float responseWaitThree;





    void Awake()
    {
        narrativeSystem = GameObject.Find("NarrativeSystem");

        UI = transform.parent.gameObject.GetComponent<UiSystem>();
        choiceBox = transform.FindChild("ChoiceBox").gameObject;
        choiceOptionOne = choiceBox.transform.FindChild("Option1").gameObject;
        choiceOptionTwo = choiceBox.transform.FindChild("Option2").gameObject;
        choiceOptionThree = choiceBox.transform.FindChild("Option3").gameObject;

        choiceOptionOneText = choiceOptionOne.transform.FindChild("Text").gameObject;
        choiceOptionTwoText = choiceOptionTwo.transform.FindChild("Text").gameObject;
        choiceOptionThreeText = choiceOptionThree.transform.FindChild("Text").gameObject;

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

                choiceResponse = responseName + ":" + "\n" + "\n" + responseOne;
                choiceWait = responseWaitOne;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                selectedOption = 2;

                Unselected(choiceOptionOne);
                Selected(choiceOptionTwo);
                Unselected(choiceOptionThree);

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

                    choiceResponse = responseName + ":" + "\n" + "\n" + responseThree;
                    choiceWait = responseWaitThree;
                }
            }


            if(selectedOption == 1 || selectedOption == 2 || selectedOption == 3)
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
            moreChoices = true;

            choiceOptionThreeText.GetComponent<Text>().text = c.choice[2];
            responseThree = c.response[2];
            responseWaitThree = c.wait[2];

            choiceOptionOne.transform.localPosition = new Vector3(0, -200);
            choiceOptionTwo.transform.localPosition = new Vector3(-250, -400);
            choiceOptionThree.transform.localPosition = new Vector3(250, -400);

        } else
        {
            choiceOptionThree.SetActive(false);
            moreChoices = false;

            choiceOptionOne.transform.localPosition = new Vector2(-250, -300);
            choiceOptionTwo.transform.localPosition = new Vector2(250, -300);
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
    }
}