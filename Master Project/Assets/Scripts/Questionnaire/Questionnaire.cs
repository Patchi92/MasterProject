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

    string ageInfo;
    string genderInfo;
    string gameHourInfo;
    string favoriteGameOneInfo;
    string favoriteGameTwoInfo;
    string favoriteGameThreeInfo;


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



    public GameObject nextButton;
    public GameObject nextButtonText;

    public GameObject thanksPlaying;

    // Temp Data

    


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

            questionOneText.GetComponent<Text>().text = "While playing, I lost track of time.";
            questionTwoText.GetComponent<Text>().text = "I was able to concentrate on the game during play.";
            questionThreeText.GetComponent<Text>().text = "During play, I sometimes found my mind wandering / found I was thinking of other things.";
            questionFourText.GetComponent<Text>().text = "During play, I noticed a lot of small details about the game.";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 3)
        {
            questionOneText.GetComponent<Text>().text = "During the game, I found myself paying more attention to my real-world surroundings, rather than the story of the game.";
            questionTwoText.GetComponent<Text>().text = "During play, I felt like part of the story.";
            questionThreeText.GetComponent<Text>().text = "During play, I was eager to find out what would happen next.";
            questionFourText.GetComponent<Text>().text = "During the game, I felt like the narrative had created a world that I, as a player, was living in, while playing.";

            ToggleOff();

            pageLock = true;
            

        }

        if (pageInfo == 4)
        {
            questionOneText.GetComponent<Text>().text = "I tried to explore the world, as much as possible.";
            questionTwoText.GetComponent<Text>().text = "I didn’t really feel like the choices I made, during the game, had a noticeable effect on the story.";
            questionThreeText.GetComponent<Text>().text = "I tried to find alternative ways to complete the game.";
            questionFourText.GetComponent<Text>().text = "I felt that the game was very linear, leaving little to no room for exploration and experimentation.";

            ToggleOff();

            pageLock = true;
            pageLast = true;

        }

        if (pageInfo == 4)
        {
            narrativeSystem.GetComponent<NarrativeSystem>().ChapterSelect(2);
            gameObject.SetActive(false);

            questionOneText.GetComponent<Text>().text = "I tried to explore the world, as much as possible.";
            questionTwoText.GetComponent<Text>().text = "I didn’t really feel like the choices I made, during the game, had a noticeable effect on the story.";
            questionThreeText.GetComponent<Text>().text = "I tried to find alternative ways to complete the game.";
            questionFourText.GetComponent<Text>().text = "I felt that the game was very linear, leaving little to no room for exploration and experimentation.";

            ToggleOff();

            pageLock = true;
            pageLast = true;

        }

        if (pageInfo == 5)
        {

            thanksPlaying.SetActive(true);
            nextButtonText.GetComponent<Text>().text = "Quit";
        }

        if (pageInfo == 6)
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

            gameHourInfo = gameHour.GetComponent<InputField>().text;
            favoriteGameOneInfo = favoriteGameOne.GetComponent<InputField>().text;
            favoriteGameTwoInfo = favoriteGameTwo.GetComponent<InputField>().text;
            favoriteGameThreeInfo = favoriteGameThree.GetComponent<InputField>().text;

            if (age.GetComponent<InputField>().text != "" && gameHour.GetComponent<InputField>().text != "" && favoriteGameOne.GetComponent<InputField>().text != "" && favoriteGameTwo.GetComponent<InputField>().text != "" && favoriteGameThree.GetComponent<InputField>().text != "")
            {
                if(male.GetComponent<Toggle>().isOn == true || female.GetComponent<Toggle>().isOn == true)
                {
                    pageLock = false;
                }
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
                        sw.Write("A ;; "); 
                    }

                    if (PlayerPrefs.GetString("Version") == "Complex")
                    {
                        sw.Write("B ;; ");
                    }

                    if (PlayerPrefs.GetString("Version") == "Mixed")
                    {
                        sw.Write("C ;; ");
                    }


                    // Demographic
                    sw.Write("Demographic");
                    sw.Write(ageInfo + " ;; " + genderInfo + " ;; " + gameHourInfo + " ;; " + favoriteGameOneInfo + " ;; " + favoriteGameTwoInfo + " ;; " + favoriteGameThreeInfo + " ;; ");
                    sw.Write("");

                    // Narrative Path
                    sw.Write("Narrative Path");
                    sw.Write(PlayerPrefs.GetString("PlayerType").ToString() + " ;; ");
                    sw.Write("");

                    // Player Behavior
                    sw.Write("Player Behavior");
                    sw.Write(PlayerPrefs.GetInt("Destruction").ToString() + " ;; " + PlayerPrefs.GetInt("Excitement").ToString() + " ;; " + PlayerPrefs.GetInt("Challenge").ToString() + " ;; " + PlayerPrefs.GetInt("Strategy").ToString() + " ;; " + PlayerPrefs.GetInt("Completion").ToString() + " ;; " + PlayerPrefs.GetInt("Power").ToString() + " ;; " + PlayerPrefs.GetInt("Fantasy").ToString() + " ;; " + PlayerPrefs.GetInt("Story").ToString() + " ;; " + PlayerPrefs.GetInt("Design").ToString() + " ;; " + PlayerPrefs.GetInt("Discovery").ToString() + " ;; ");
                    sw.Write("");

                    // CD Questions: Round 1
                    sw.Write("CD Questions: Round 1");
                    sw.Write("test");
                    sw.Write("");

                    // CD Questions: Round 2
                    sw.Write("CD Questions: Round 2");
                    sw.Write("test");
                    sw.Write("");



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
            
        }

        if (questionOneB.GetComponent<Toggle>().isOn == true)
        {
            
        }

        if (questionOneC.GetComponent<Toggle>().isOn == true)
        {
           
        }

        if (questionOneD.GetComponent<Toggle>().isOn == true)
        {
            
        }

        if (questionOneE.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {
                oneCDQuestionOne = 5;
                oneCDQuestionFour = 5;
                oneCDQuestionEight = 5;
                oneCDQuestionTwelve = 5;
            }
        }

        // Question 2

        if (questionTwoA.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {
                oneCDQuestionTwo = 1;
                oneCDQuestionFive = 1;
                oneCDQuestionNine = 1;
                oneCDQuestionThirteen = 1;
            }
        }

        if (questionTwoB.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {
                oneCDQuestionTwo = 2;
                oneCDQuestionFive = 2;
                oneCDQuestionNine = 2;
                oneCDQuestionThirteen = 2;
            }
        }

        if (questionTwoC.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {
                oneCDQuestionTwo = 1;
                oneCDQuestionFive = 1;
                oneCDQuestionNine = 1;
                oneCDQuestionThirteen = 1;
            }
        }

        if (questionTwoD.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {
                oneCDQuestionTwo = 1;
                oneCDQuestionFive = 1;
                oneCDQuestionNine = 1;
                oneCDQuestionThirteen = 1;

            }
        }

        if (questionTwoE.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {
                oneCDQuestionTwo = 1;
                oneCDQuestionFive = 1;
                oneCDQuestionNine = 1;
                oneCDQuestionThirteen = 1;
            }
        }


        // Question 3

        if (questionThreeA.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionThreeB.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionThreeC.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionThreeD.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionThreeE.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        // Question 4

        if (questionFourA.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionFourB.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionFourC.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionFourD.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionFourE.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
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
