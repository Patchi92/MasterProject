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

    public bool ignoreMixed;

    //Input
    float mouseX;
    float mouseY;
    bool mouseCheck;


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
        mouseCheck = false;
        ignoreMixed = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (UI.choice)
        {
            choiceBox.SetActive(true);

            if (!mouseCheck)
            {
                mouseX = Input.mousePosition.x;
                mouseY = Input.mousePosition.y;
                mouseCheck = true;
                StartCoroutine("MouseCD");

            }

            if (moreChoices)
            {

                if (Input.GetKeyDown(KeyCode.Alpha1) || (mouseY + 50) < Input.mousePosition.y)
                {

                    if (PlayerPrefs.GetString("Version") == "Mixed")
                    {
                        if(ignoreMixed)
                        {
                            selectedOption = 1;

                            Selected(choiceOptionOne);
                            Unselected(choiceOptionTwo);
                            Unselected(choiceOptionThree);

                            choiceResponse = responseName + ":" + "\n" + "\n" + responseOne;
                            choiceWait = responseWaitOne;
                        }
                        else if (PlayerPrefs.GetInt("KillerPoints") < 1)
                        {
                            selectedOption = 1;

                            Selected(choiceOptionOne);

                            if (PlayerPrefs.GetInt("NPCsKilled") == 0 && PlayerPrefs.GetInt("HeroPoints") == 0)
                            {
                                Unselected(choiceOptionTwo);
                            }

                            if (PlayerPrefs.GetInt("HeroPoints") < 5)
                            {
                                Unselected(choiceOptionThree);
                            }

                            choiceResponse = responseName + ":" + "\n" + "\n" + responseOne;
                            choiceWait = responseWaitOne;
                        }
                    }
                    else
                    {
                        selectedOption = 1;

                        Selected(choiceOptionOne);
                        Unselected(choiceOptionTwo);
                        Unselected(choiceOptionThree);

                        choiceResponse = responseName + ":" + "\n" + "\n" + responseOne;
                        choiceWait = responseWaitOne;
                    }
                }

                else if (Input.GetKeyDown(KeyCode.Alpha2) || (mouseX - 50) > Input.mousePosition.x)
                {
                    if (PlayerPrefs.GetString("Version") == "Mixed")
                    {

                        if (ignoreMixed)
                        {
                            selectedOption = 2;

                            Unselected(choiceOptionOne);
                            Selected(choiceOptionTwo);
                            Unselected(choiceOptionThree);

                            choiceResponse = responseName + ":" + "\n" + "\n" + responseTwo;
                            choiceWait = responseWaitTwo;
                        }
                        else if (PlayerPrefs.GetInt("NPCsKilled") == 0 && PlayerPrefs.GetInt("HeroPoints") == 0)
                        {
                            selectedOption = 2;

                            if (PlayerPrefs.GetInt("KillerPoints") < 1)
                            {
                                Unselected(choiceOptionOne);
                            }

                            Selected(choiceOptionTwo);

                            if (PlayerPrefs.GetInt("HeroPoints") < 5)
                            {
                                Unselected(choiceOptionThree);
                            }

                            choiceResponse = responseName + ":" + "\n" + "\n" + responseTwo;
                            choiceWait = responseWaitTwo;
                        }
                    }
                    else
                    {
                        selectedOption = 2;

                        Unselected(choiceOptionOne);
                        Selected(choiceOptionTwo);
                        Unselected(choiceOptionThree);

                        choiceResponse = responseName + ":" + "\n" + "\n" + responseTwo;
                        choiceWait = responseWaitTwo;
                    }
                }

                else if (Input.GetKeyDown(KeyCode.Alpha3) || (mouseX + 50) < Input.mousePosition.x)
                {
                    if (moreChoices == true)
                    {
                        if (PlayerPrefs.GetString("Version") == "Mixed")
                        {
                            if (ignoreMixed)
                            {
                                selectedOption = 3;

                                Unselected(choiceOptionOne);
                                Unselected(choiceOptionTwo);
                                Selected(choiceOptionThree);

                                choiceResponse = responseName + ":" + "\n" + "\n" + responseThree;
                                choiceWait = responseWaitThree;
                            }
                            else if (PlayerPrefs.GetInt("HeroPoints") < 5)
                            {
                                selectedOption = 3;

                                if (PlayerPrefs.GetInt("KillerPoints") < 1)
                                {
                                    Unselected(choiceOptionOne);
                                }

                                if ((PlayerPrefs.GetInt("NPCsKilled") == 0 && PlayerPrefs.GetInt("HeroPoints") == 0))
                                {
                                    Unselected(choiceOptionTwo);
                                }

                                Selected(choiceOptionThree);

                                choiceResponse = responseName + ":" + "\n" + "\n" + responseThree;
                                choiceWait = responseWaitThree;
                            }
                        }
                        else
                        {
                            selectedOption = 3;

                            Unselected(choiceOptionOne);
                            Unselected(choiceOptionTwo);
                            Selected(choiceOptionThree);

                            choiceResponse = responseName + ":" + "\n" + "\n" + responseThree;
                            choiceWait = responseWaitThree;
                        }
                    }
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) || (mouseX - 50) > Input.mousePosition.x)
                {
                    selectedOption = 1;
                    Selected(choiceOptionOne);
                    Unselected(choiceOptionTwo);

                    choiceResponse = responseName + ":" + "\n" + "\n" + responseOne;
                    choiceWait = responseWaitOne;
                }

                if (Input.GetKeyDown(KeyCode.Alpha2) || (mouseX + 50) < Input.mousePosition.x)

                {
                    selectedOption = 2;
                    Selected(choiceOptionTwo);
                    Unselected(choiceOptionOne);

                    choiceResponse = responseName + ":" + "\n" + "\n" + responseTwo;
                    choiceWait = responseWaitTwo;
                }

            }
            if(selectedOption == 1 || selectedOption == 2 || selectedOption == 3)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
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

            choiceOptionOne.transform.localPosition = new Vector3(0, 0);
            choiceOptionTwo.transform.localPosition = new Vector3(-200, -200);
            choiceOptionTwo.transform.GetChild(0).transform.localPosition = new Vector3(-220, 0);
            choiceOptionTwo.transform.GetChild(1).transform.localPosition = new Vector3(-220, -30);

            choiceOptionThree.transform.localPosition = new Vector3(200, -200);

            if (c.removeSymbol == true)
            {
                choiceOptionOne.transform.GetChild(2).gameObject.SetActive(false);
                choiceOptionTwo.transform.GetChild(2).gameObject.SetActive(false);
                choiceOptionThree.transform.GetChild(2).gameObject.SetActive(false);
            } else
            {
                choiceOptionOne.transform.GetChild(2).gameObject.SetActive(true);
                choiceOptionTwo.transform.GetChild(2).gameObject.SetActive(true);
                choiceOptionThree.transform.GetChild(2).gameObject.SetActive(true);
            }

        } else
        {
            choiceOptionThree.SetActive(false);
            moreChoices = false;

            choiceOptionOne.transform.localPosition = new Vector2(-200, -200);
            choiceOptionTwo.transform.localPosition = new Vector2(200, -200);
            choiceOptionTwo.transform.GetChild(0).transform.localPosition = new Vector3(0, 140);
            choiceOptionTwo.transform.GetChild(1).transform.localPosition = new Vector3(0, 110);

            choiceOptionOne.transform.GetChild(2).gameObject.SetActive(false);
            choiceOptionTwo.transform.GetChild(2).gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetString("Version") == "Mixed")
        {
            if (moreChoices == true)
            {
                if(ignoreMixed)
                {
                    Unselected(choiceOptionOne);
                }
                else if (PlayerPrefs.GetInt("KillerPoints") > 0)
                {
                    Unavalible(choiceOptionOne);
                }
                else
                {
                    Unselected(choiceOptionOne);
                }

                if (ignoreMixed)
                {
                    Unselected(choiceOptionTwo);
                }
                else if (PlayerPrefs.GetInt("NPCsKilled") == 0 && PlayerPrefs.GetInt("HeroPoints") == 0)
                {
                    Unselected(choiceOptionTwo);
                }
                else
                {
                    Unavalible(choiceOptionTwo);
                }

                if (ignoreMixed)
                {
                    Unselected(choiceOptionThree);
                }
                else if (PlayerPrefs.GetInt("HeroPoints") > 5)
                {
                    Unavalible(choiceOptionThree);
                }
                else
                {
                    Unselected(choiceOptionThree);
                }
            }
            else
            {
                Unselected(choiceOptionOne);
                Unselected(choiceOptionTwo);
            }
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

    IEnumerator MouseCD()
    {
        yield return new WaitForSeconds(1f);
        mouseCheck = false;
    }
}