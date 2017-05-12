using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


public class Questionnaire : MonoBehaviour
{

    //Player
    GameObject narrativeSystem;

    //System

    string path;
    
    bool pageLock;
    int pageInfo;
    bool pageLast;

    // Demographic

    public GameObject demographicQuestions;

    public GameObject age;
    public GameObject male;
    public GameObject female;
    public GameObject gameHour;
    public GameObject favoriteGameOne;
    public GameObject favoriteGameTwo;
    public GameObject favoriteGameThree;

    public GameObject playSDisagree;
    public GameObject playDisagree;
    public GameObject playNeutral;
    public GameObject playAgree;
    public GameObject playSAgree;

    string ageInfo;
    string genderInfo;
    string gameHourInfo;
    string favoriteGameOneInfo;
    string favoriteGameTwoInfo;
    string favoriteGameThreeInfo;
    int wannaPlay;


    // Questionnaire

    public GameObject questionnaireQuestions;

    public GameObject questionOneText;
    public GameObject questionOneA;
    public GameObject questionOneB;
    public GameObject questionOneC;
    public GameObject questionOneD;
    public GameObject questionOneE;

    public GameObject questionTwoText;
    public GameObject questionTwoA;
    public GameObject questionTwoB;
    public GameObject questionTwoC;
    public GameObject questionTwoD;
    public GameObject questionTwoE;

    public GameObject questionThreeText;
    public GameObject questionThreeA;
    public GameObject questionThreeB;
    public GameObject questionThreeC;
    public GameObject questionThreeD;
    public GameObject questionThreeE;

    public GameObject questionFourText;
    public GameObject questionFourA;
    public GameObject questionFourB;
    public GameObject questionFourC;
    public GameObject questionFourD;
    public GameObject questionFourE;


    string questionOne;
    string questionTwo;
    string questionThree;
    string questionFour;

    // Narrative Feedback

    public GameObject narrativeFeedback;

    public GameObject story;
    public GameObject behavior;
    public GameObject actions;
    public GameObject feedback;



    public GameObject nextButton;
    public GameObject nextButtonText;

    public GameObject thanksPlaying;

    // Temp Data

    int tempDataOne;
    int tempDataTwo;
    int tempDataThree;
    int tempDataFour;



    // Data Part 1

    int oneCDQuestionOne;
    int oneCDQuestionTwo;
    int oneCDQuestionThree;
    int oneCDQuestionFour;

    int oneCDQuestionFive;
    int oneCDQuestionSix;
    int oneCDQuestionSeven;
    int oneCDQuestionEight;

    int oneCDQuestionNine;
    int oneCDQuestionTen;
    int oneCDQuestionEleven;
    int oneCDQuestionTwelve;

    int oneCDQuestionThirteen;
    int oneCDQuestionFourteen;
    int oneCDQuestionFifthteen;
    int oneCDQuestionSixteen;

    // Data Part 2

    int twoCDQuestionOne;
    int twoCDQuestionTwo;
    int twoCDQuestionThree;
    int twoCDQuestionFour;

    int twoCDQuestionFive;
    int twoCDQuestionSix;
    int twoCDQuestionSeven;
    int twoCDQuestionEight;

    int twoCDQuestionNine;
    int twoCDQuestionTen;
    int twoCDQuestionEleven;
    int twoCDQuestionTwelve;

    int twoCDQuestionThirteen;
    int twoCDQuestionFourteen;
    int twoCDQuestionFifthteen;
    int twoCDQuestionSixteen;

    int twoCDQuestionSeventeen;
    int twoCDQuestionEighteen;
    int twoCDQuestionNineteen;
    int twoCDQuestionTwenty;

    int twoCDQuestionTwentyOne;
    int twoCDQuestionTwentyTwo;
    int twoCDQuestionTwentyThree;
    int twoCDQuestionTwentyFour;

    int twoCDQuestionTwentyFive;
    int twoCDQuestionTwentySix;
    int twoCDQuestionTwentySeven;
    int twoCDQuestionTwentyEight;

    int twoCDQuestionTwentyNine;
    int twoCDQuestionThirty;
    int twoCDQuestionThirtyOne;
    int twoCDQuestionThirtyTwo;

    int twoCDQuestionThirtyThree;
    int twoCDQuestionThirtyFour;
    int twoCDQuestionThirtyFive;
    int twoCDQuestionThirtySix;

    int twoCDQuestionThirtySeven;
    int twoCDQuestionThirtyEight;
    int twoCDQuestionThirtyNine;
    int twoCDQuestionFourty;



    // Use this for initialization
    void Start()
    {

        path = Application.dataPath;

        if (!System.IO.Directory.Exists(path + "/TestData"))
        {
            System.IO.Directory.CreateDirectory(path + "/TestData");
        }


        narrativeSystem = GameObject.Find("NarrativeSystem");

        pageInfo = 1;
        pageLast = false;
        PageUpdate();

    }

    // Update is called once per frame
    void Update()
    {

        Cursor.visible = true;
    }

    void PageUpdate()
    {
        if (pageInfo == 1)
        {


            pageLock = true;
            demographicQuestions.SetActive(true);
            questionnaireQuestions.SetActive(false);
            nextButton.SetActive(false);
        }

        if (pageInfo == 2)
        {
            narrativeSystem.GetComponent<NarrativeSystem>().ChapterSelect(1);
            gameObject.SetActive(false);

            demographicQuestions.SetActive(false);
            questionnaireQuestions.SetActive(true);
            nextButton.SetActive(true);

            questionOneText.GetComponent<Text>().text = "Would you like to continue.";
            questionTwoText.GetComponent<Text>().text = "While playing, I lost track of time.";
            questionThreeText.GetComponent<Text>().text = "I was able to concentrate on the game during play.";
            questionFourText.GetComponent<Text>().text = "During play, I sometimes found my mind wandering / found I was thinking of other things";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 3)
        {
            oneCDQuestionOne = tempDataOne;
            oneCDQuestionTwo = tempDataTwo;
            oneCDQuestionThree = tempDataThree;
            oneCDQuestionFour = tempDataFour;


            questionOneText.GetComponent<Text>().text = "During play, I noticed a lot of small details about the game.";
            questionTwoText.GetComponent<Text>().text = "During the game, I found myself paying more attention to my real-world surroundings, rather than the story of the game.";
            questionThreeText.GetComponent<Text>().text = "During play, I felt like part of the story.";
            questionFourText.GetComponent<Text>().text = "During play, I was eager to find out what would happen next.";

            ToggleOff();

            pageLock = true;
            

        }

        if (pageInfo == 4)
        {
            oneCDQuestionFive = tempDataOne;
            oneCDQuestionSix = tempDataTwo;
            oneCDQuestionSeven = tempDataThree;
            oneCDQuestionEight = tempDataFour;

            questionOneText.GetComponent<Text>().text = "During the game, I felt like the narrative had created a world that I, as a player, was living in, while playing.";
            questionTwoText.GetComponent<Text>().text = "I tried to explore the world, as much as possible.";
            questionThreeText.GetComponent<Text>().text = "I didn’t really feel like the choices I made, during the game, had a noticeable effect on the story.";
            questionFourText.GetComponent<Text>().text = "I tried to find alternative ways to complete the game.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 5)
        {
            oneCDQuestionNine = tempDataOne;
            oneCDQuestionTen = tempDataTwo;
            oneCDQuestionEleven = tempDataThree;
            oneCDQuestionTwelve = tempDataFour;

            questionOneText.GetComponent<Text>().text = "I felt that the game was very linear, leaving little to no room for exploration and experimentation.";
            questionTwoText.GetComponent<Text>().text = "Parts of the story are formed by me in the course of playing the game.";
            questionThreeText.GetComponent<Text>().text = "Some tasks or conflicts in the game story are stimulating and suspenseful.";
            questionFourText.GetComponent<Text>().text = "I feel successful when i overcome the obstacles, tasks or opponents in the game.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 6)
        {
            oneCDQuestionThirteen = tempDataOne;
            oneCDQuestionFourteen = tempDataTwo;
            oneCDQuestionFifthteen = tempDataThree;
            oneCDQuestionSixteen = tempDataFour;

            questionOneText.GetComponent<Text>().text = "Would you like to continue.";
            questionTwoText.GetComponent<Text>().text = "While playing, I lost track of time.";
            questionThreeText.GetComponent<Text>().text = "I was able to concentrate on the game during play.";
            questionFourText.GetComponent<Text>().text = "During play, I sometimes found my mind wandering / found I was thinking of other things.";

            ToggleOff();

            pageLock = true;

            narrativeSystem.GetComponent<NarrativeSystem>().ChapterSelect(2);
            gameObject.SetActive(false);

        }


        if (pageInfo == 7)
        {
            twoCDQuestionOne = tempDataOne;
            twoCDQuestionTwo = tempDataTwo;
            twoCDQuestionThree = tempDataThree;
            twoCDQuestionFour = tempDataFour;

            questionOneText.GetComponent<Text>().text = "During play, I noticed a lot of small details about the game.";
            questionTwoText.GetComponent<Text>().text = "During the game, I found myself paying more attention to my real-world surroundings, rather than the story of the game.";
            questionThreeText.GetComponent<Text>().text = "During play, I felt like part of the story.";
            questionFourText.GetComponent<Text>().text = "During play, I was eager to find out what would happen next.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 8)
        {
            twoCDQuestionFive = tempDataOne;
            twoCDQuestionSix = tempDataTwo;
            twoCDQuestionSeven = tempDataThree;
            twoCDQuestionEight = tempDataFour;

            questionOneText.GetComponent<Text>().text = "During the game, I felt like the narrative had created a world that I, as a player, was living in, while playing.";
            questionTwoText.GetComponent<Text>().text = "The story quickly grabs my attention at the beginning.";
            questionThreeText.GetComponent<Text>().text = "I found the story logical and convincing.";
            questionFourText.GetComponent<Text>().text = "I felt like I understood why the characters were acting the way they did.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 9)
        {
            twoCDQuestionNine = tempDataOne;
            twoCDQuestionTen = tempDataTwo;
            twoCDQuestionEleven = tempDataThree;
            twoCDQuestionTwelve = tempDataFour;

            questionOneText.GetComponent<Text>().text = "During the game, I had a feeling that I knew what would happen next.";
            questionTwoText.GetComponent<Text>().text = "I felt that the plot of the story was very predictable and uninspiring";
            questionThreeText.GetComponent<Text>().text = "I am not sure that I understand the characters ";
            questionFourText.GetComponent<Text>().text = "I had an easy time identifying with the characters in the story.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 10)
        {
            twoCDQuestionThirteen = tempDataOne;
            twoCDQuestionFourteen = tempDataTwo;
            twoCDQuestionFifthteen = tempDataThree;
            twoCDQuestionSixteen = tempDataFour;

            questionOneText.GetComponent<Text>().text = "I felt like I was able to understand the events of the story, in a similar way to how the characters of the game understood them. ";
            questionTwoText.GetComponent<Text>().text = "I could easily imagine myself being put in the situation of some of the characters.";
            questionThreeText.GetComponent<Text>().text = "At some points, during the game, I felt an emotional connection with some of the characters.";
            questionFourText.GetComponent<Text>().text = "The story had no emotional effect on me.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 11)
        {
            twoCDQuestionSeventeen = tempDataOne;
            twoCDQuestionEighteen = tempDataTwo;
            twoCDQuestionNineteen = tempDataThree;
            twoCDQuestionTwenty = tempDataFour;

            questionOneText.GetComponent<Text>().text = "After finishing the game, it takes a long time for me to return to the real world psychologically and emotionally.";
            questionTwoText.GetComponent<Text>().text = "I tried to explore the world, as much as possible.";
            questionThreeText.GetComponent<Text>().text = "If I had the chance, I would have changed some of the choices I made during the game.";
            questionFourText.GetComponent<Text>().text = "I didn’t really feel like the choices I made, during the game, had a noticeable effect on the story. ";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 12)
        {
            twoCDQuestionTwentyOne = tempDataOne;
            twoCDQuestionTwentyTwo = tempDataTwo;
            twoCDQuestionTwentyThree = tempDataThree;
            twoCDQuestionTwentyFour = tempDataFour;

            questionOneText.GetComponent<Text>().text = "I tried to find alternative ways to complete the game.";
            questionTwoText.GetComponent<Text>().text = "I felt that the game was very linear, leaving little to no room for exploration and experimentation.";
            questionThreeText.GetComponent<Text>().text = "I felt like my choices didn’t really matter to the outcome of the story.";
            questionFourText.GetComponent<Text>().text = "I didn’t understand the goals of the characters.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 13)
        {
            twoCDQuestionTwentyFive = tempDataOne;
            twoCDQuestionTwentySix = tempDataTwo;
            twoCDQuestionTwentySeven = tempDataThree;
            twoCDQuestionTwentyEight = tempDataFour;

            questionOneText.GetComponent<Text>().text = "I felt that the gameworld was both rich and interesting.";
            questionTwoText.GetComponent<Text>().text = "I found the story interesting.";
            questionThreeText.GetComponent<Text>().text = "While playing, I felt a bit too stressed about other things, to really enjoy the game. ";
            questionFourText.GetComponent<Text>().text = "Parts of the story are formed by me in the course of playing the game.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 14)
        {
            twoCDQuestionTwentyNine = tempDataOne;
            twoCDQuestionThirty = tempDataTwo;
            twoCDQuestionThirtyOne = tempDataThree;
            twoCDQuestionThirtyTwo = tempDataFour;

            PlayerPrefs.SetInt("Fantasy", twoCDQuestionTwentyNine);

            questionOneText.GetComponent<Text>().text = "Some tasks or conflicts in the game story are stimulating and suspenseful.";
            questionTwoText.GetComponent<Text>().text = "I feel successful when i overcome the obstacles, tasks or opponents in the game.";
            questionThreeText.GetComponent<Text>().text = "I can control the game interface.";
            questionFourText.GetComponent<Text>().text = "I can control the character to move according to my arrangement";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 15)
        {
            twoCDQuestionThirtyThree = tempDataOne;
            twoCDQuestionThirtyFour = tempDataTwo;
            twoCDQuestionThirtyFive = tempDataThree;
            twoCDQuestionThirtySix = tempDataFour;

            questionOneText.GetComponent<Text>().text = "I am interested in the style of the game interface.";
            questionTwoText.GetComponent<Text>().text = "I am familiar with the cultural background.";
            questionThreeText.GetComponent<Text>().text = "I found many events in the game story original.";
            questionFourText.GetComponent<Text>().text = "I recognise some of story presented in the game.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 16)
        {
            twoCDQuestionThirtySeven = tempDataOne;
            twoCDQuestionThirtyEight = tempDataTwo;
            twoCDQuestionThirtyNine = tempDataThree;
            twoCDQuestionFourty = tempDataFour;

            ToggleOff();


            

            // Narrative Questions

            questionnaireQuestions.SetActive(false);
            narrativeFeedback.SetActive(true);

            pageLast = true;
            pageLock = true;
        }





        if (pageInfo == 17)
        {
            thanksPlaying.SetActive(true);
            nextButtonText.GetComponent<Text>().text = "Quit";




        }


        if (pageInfo == 18)
        {
            Application.Quit();

        }
    }

    public void NextPage()
    {
        if (pageInfo == 1)
        {
            ageInfo = age.GetComponent<InputField>().text;

            if (male.GetComponent<Toggle>().isOn == true)
            {
                genderInfo = "Male";
            } else {
                genderInfo = "Female";
            }

            if (playSDisagree.GetComponent<Toggle>().isOn == true)
            {
                wannaPlay = 1;
            } else if (playDisagree.GetComponent<Toggle>().isOn == true)
            {
                wannaPlay = 2;
            } else if (playNeutral.GetComponent<Toggle>().isOn == true)
            {
                wannaPlay = 3;
            } else if (playAgree.GetComponent<Toggle>().isOn == true)
            {
                wannaPlay = 4;
            } else if (playSAgree.GetComponent<Toggle>().isOn == true)
            {
                wannaPlay = 5;
            }



            gameHourInfo = gameHour.GetComponent<InputField>().text;
            favoriteGameOneInfo = favoriteGameOne.GetComponent<InputField>().text;
            favoriteGameTwoInfo = favoriteGameTwo.GetComponent<InputField>().text;
            favoriteGameThreeInfo = favoriteGameThree.GetComponent<InputField>().text;

            if (age.GetComponent<InputField>().text != "" && gameHour.GetComponent<InputField>().text != "" && favoriteGameOne.GetComponent<InputField>().text != "" && favoriteGameTwo.GetComponent<InputField>().text != "" && favoriteGameThree.GetComponent<InputField>().text != "")
            {
                if (male.GetComponent<Toggle>().isOn == true || female.GetComponent<Toggle>().isOn == true)
                {
                    if (playSDisagree.GetComponent<Toggle>().isOn == true || playDisagree.GetComponent<Toggle>().isOn == true || playNeutral.GetComponent<Toggle>().isOn == true || playAgree.GetComponent<Toggle>().isOn == true || playSAgree.GetComponent<Toggle>().isOn == true)
                    {
                        pageLock = false;
                    }
                }
            }
        } else if (pageInfo == 16) {

            if (story.GetComponent<InputField>().text != "" && behavior.GetComponent<InputField>().text != "" && actions.GetComponent<InputField>().text != "" && feedback.GetComponent<InputField>().text != "")
            {
                pageLock = false;
            }

        } else  {

                ToggleUpdate();

                if(questionOneA.GetComponent<Toggle>().isOn == true || questionOneB.GetComponent<Toggle>().isOn == true || questionOneC.GetComponent<Toggle>().isOn == true || questionOneD.GetComponent<Toggle>().isOn == true || questionOneE.GetComponent<Toggle>().isOn == true) {
                    if (questionTwoA.GetComponent<Toggle>().isOn == true || questionTwoB.GetComponent<Toggle>().isOn == true || questionTwoC.GetComponent<Toggle>().isOn == true || questionTwoD.GetComponent<Toggle>().isOn == true || questionTwoE.GetComponent<Toggle>().isOn == true) {
                        if (questionThreeA.GetComponent<Toggle>().isOn == true || questionThreeB.GetComponent<Toggle>().isOn == true || questionThreeC.GetComponent<Toggle>().isOn == true || questionThreeD.GetComponent<Toggle>().isOn == true || questionThreeE.GetComponent<Toggle>().isOn == true) {
                            if (questionFourA.GetComponent<Toggle>().isOn == true || questionFourB.GetComponent<Toggle>().isOn == true || questionFourC.GetComponent<Toggle>().isOn == true || questionFourD.GetComponent<Toggle>().isOn == true || questionFourE.GetComponent<Toggle>().isOn == true) {
                                pageLock = false;
                            }
                        }
                    }
                }
        }
       

        if(!pageLock)
        {

            if (pageLast == true)
            {

                using (StreamWriter sw = File.CreateText((path + "/TestData/TestInfo.txt")))
                {
                    if(PlayerPrefs.GetString("Version") == "Simple")
                    {
                        sw.WriteLine("A ;; Simple"); 
                    }

                    if (PlayerPrefs.GetString("Version") == "Complex")
                    {
                        sw.WriteLine("B ;; Complex");
                    }

                    if (PlayerPrefs.GetString("Version") == "Mixed")
                    {
                        sw.WriteLine("C ;; Mixed");
                    }


                    // Demographic
                    sw.WriteLine("Demographic");
                    sw.WriteLine(ageInfo + " ;; " + genderInfo + " ;; " + gameHourInfo + " ;; " + favoriteGameOneInfo + " ;; " + favoriteGameTwoInfo + " ;; " + favoriteGameThreeInfo + " ;; " + wannaPlay);
                    sw.WriteLine("");

                    // Narrative Feedback
                    sw.WriteLine("Narrative Feedback");
                    sw.WriteLine("Narrative Path: " + PlayerPrefs.GetString("PlayerType").ToString());
                    sw.WriteLine("");
                    sw.WriteLine(story.GetComponent<InputField>().text);
                    sw.WriteLine("");
                    sw.WriteLine(behavior.GetComponent<InputField>().text);
                    sw.WriteLine("");
                    sw.WriteLine(actions.GetComponent<InputField>().text);
                    sw.WriteLine("");
                    sw.WriteLine(feedback.GetComponent<InputField>().text);
                    sw.WriteLine("");
                    sw.WriteLine("");

                    // Player Behavior
                    sw.WriteLine("Player Behavior");
                    sw.WriteLine(PlayerPrefs.GetInt("Destruction").ToString() + " ;; " + PlayerPrefs.GetInt("Excitement").ToString() + " ;; " + PlayerPrefs.GetInt("Challenge").ToString() + " ;; " + PlayerPrefs.GetInt("Strategy").ToString() + " ;; " + PlayerPrefs.GetInt("Completion").ToString() + " ;; " + PlayerPrefs.GetInt("Power").ToString() + " ;; " + PlayerPrefs.GetInt("Fantasy").ToString() + " ;; " + PlayerPrefs.GetInt("Story").ToString() + " ;; " + PlayerPrefs.GetInt("Design").ToString() + " ;; " + PlayerPrefs.GetInt("Discovery").ToString());
                    sw.WriteLine("");

                    // CD Questions: Round 1
                    sw.WriteLine("CD Questions: Round 1");
                    sw.WriteLine(oneCDQuestionOne + " ;; " + oneCDQuestionTwo + " ;; " + oneCDQuestionThree + " ;; " + oneCDQuestionFour + " ;; " + oneCDQuestionFive + " ;; " + oneCDQuestionSix + " ;; " + oneCDQuestionSeven + " ;; " + oneCDQuestionEight + " ;; " + oneCDQuestionNine + " ;; " + oneCDQuestionTen + " ;; " + oneCDQuestionEleven + " ;; " + oneCDQuestionTwelve + " ;; " + oneCDQuestionThirteen + " ;; " + oneCDQuestionFourteen + " ;; " + oneCDQuestionFifthteen + " ;; " + oneCDQuestionSixteen);
                    sw.WriteLine("");

                    // CD Questions: Round 2
                    sw.WriteLine("CD Questions: Round 2");
                    sw.WriteLine(twoCDQuestionOne + " ;; " + twoCDQuestionTwo + " ;; " + twoCDQuestionThree + " ;; " + twoCDQuestionFour + " ;; " + twoCDQuestionFive + " ;; " + twoCDQuestionSix + " ;; " + twoCDQuestionSeven + " ;; " + twoCDQuestionEight + " ;; " + twoCDQuestionNine + " ;; " + twoCDQuestionTen + " ;; " + twoCDQuestionEleven + " ;; " + twoCDQuestionTwelve + " ;; " + twoCDQuestionThirteen + " ;; " + twoCDQuestionFourteen + " ;; " + twoCDQuestionFifthteen + " ;; " + twoCDQuestionSixteen + " ;; " + twoCDQuestionSeventeen + " ;; " + twoCDQuestionEighteen + " ;; " + twoCDQuestionNineteen + " ;; " + twoCDQuestionTwenty + " ;; " + twoCDQuestionTwentyOne + " ;; " + twoCDQuestionTwentyTwo + " ;; " + twoCDQuestionTwentyThree + " ;; " + twoCDQuestionTwentyFour + " ;; " + twoCDQuestionTwentyFive + " ;; " + twoCDQuestionTwentySix + " ;; " + twoCDQuestionTwentySeven + " ;; " + twoCDQuestionTwentyEight + " ;; " + twoCDQuestionTwentyNine + " ;; " + twoCDQuestionThirty + " ;; " + twoCDQuestionThirtyOne + " ;; " + twoCDQuestionThirtyTwo + " ;; " + twoCDQuestionThirtyThree + " ;; " + twoCDQuestionThirtyFour + " ;; " + twoCDQuestionThirtyFive + " ;; " + twoCDQuestionThirtySix + " ;; " + twoCDQuestionThirtySeven + " ;; " + twoCDQuestionThirtyEight + " ;; " + twoCDQuestionThirtyNine + " ;; " + twoCDQuestionFourty);
                    sw.WriteLine("");



                    //SendMail();

                    pageLast = false;
                }
                    

                
            }

            ++pageInfo;
            PageUpdate();
        }
    }

    
   


    void ToggleOff()
    {
        questionOneA.GetComponent<Toggle>().isOn = false;
        questionOneB.GetComponent<Toggle>().isOn = false;
        questionOneC.GetComponent<Toggle>().isOn = false;
        questionOneD.GetComponent<Toggle>().isOn = false;
        questionOneE.GetComponent<Toggle>().isOn = false;

        questionTwoA.GetComponent<Toggle>().isOn = false;
        questionTwoB.GetComponent<Toggle>().isOn = false;
        questionTwoC.GetComponent<Toggle>().isOn = false;
        questionTwoD.GetComponent<Toggle>().isOn = false;
        questionTwoE.GetComponent<Toggle>().isOn = false;

        questionThreeA.GetComponent<Toggle>().isOn = false;
        questionThreeB.GetComponent<Toggle>().isOn = false;
        questionThreeC.GetComponent<Toggle>().isOn = false;
        questionThreeD.GetComponent<Toggle>().isOn = false;
        questionThreeE.GetComponent<Toggle>().isOn = false;

        questionFourA.GetComponent<Toggle>().isOn = false;
        questionFourB.GetComponent<Toggle>().isOn = false;
        questionFourC.GetComponent<Toggle>().isOn = false;
        questionFourD.GetComponent<Toggle>().isOn = false;
        questionFourE.GetComponent<Toggle>().isOn = false;

    }

    void ToggleUpdate()
    {
        #region ToggleUpdate

        if (questionOneA.GetComponent<Toggle>().isOn == true)
        {
            tempDataOne = 1;
        }

        if (questionOneB.GetComponent<Toggle>().isOn == true)
        {
            tempDataOne = 2;
        }

        if (questionOneC.GetComponent<Toggle>().isOn == true)
        {
            tempDataOne = 3;
        }

        if (questionOneD.GetComponent<Toggle>().isOn == true)
        {
            tempDataOne = 4;
        }

        if (questionOneE.GetComponent<Toggle>().isOn == true)
        {
            tempDataOne = 5;
        }

        // Question 2

        if (questionTwoA.GetComponent<Toggle>().isOn == true)
        {
            tempDataTwo = 1;
        }

        if (questionTwoB.GetComponent<Toggle>().isOn == true)
        {
            tempDataTwo = 2;
        }

        if (questionTwoC.GetComponent<Toggle>().isOn == true)
        {
            tempDataTwo = 3;
        }

        if (questionTwoD.GetComponent<Toggle>().isOn == true)
        {
            tempDataTwo = 4;
        }

        if (questionTwoE.GetComponent<Toggle>().isOn == true)
        {
            tempDataTwo = 5;
        }


        // Question 3

        if (questionThreeA.GetComponent<Toggle>().isOn == true)
        {
            tempDataThree = 1;
        }

        if (questionThreeB.GetComponent<Toggle>().isOn == true)
        {
            tempDataThree = 2;
        }

        if (questionThreeC.GetComponent<Toggle>().isOn == true)
        {
            tempDataThree = 3;
        }

        if (questionThreeD.GetComponent<Toggle>().isOn == true)
        {
            tempDataThree = 4;
        }

        if (questionThreeE.GetComponent<Toggle>().isOn == true)
        {
            tempDataThree = 5;
        }

        // Question 4

        if (questionFourA.GetComponent<Toggle>().isOn == true)
        {
            tempDataFour = 1;
        }

        if (questionFourB.GetComponent<Toggle>().isOn == true)
        {
            tempDataFour = 2;
        }

        if (questionFourC.GetComponent<Toggle>().isOn == true)
        {
            tempDataFour = 3;
        }

        if (questionFourD.GetComponent<Toggle>().isOn == true)
        {
            tempDataFour = 4;
        }

        if (questionFourE.GetComponent<Toggle>().isOn == true)
        {
            tempDataFour = 5;
        }

        #endregion

    }

    void SendMail()
    {
        MailMessage mail = new MailMessage();
        System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(path + "/TestData/TestInfo.txt");

        mail.From = new MailAddress("masteraau@gmail.com");
        mail.To.Add("masteraau@gmail.com");
        mail.Subject = "Mail From Tester";
        mail.Body = "New Test Results";
        mail.Attachments.Add(attachment);

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("masteraau@gmail.com", "Pattelatte") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");
    }

}
