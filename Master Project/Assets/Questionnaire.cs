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

    




    // Use this for initialization
    void Start()
    {

        path = Application.dataPath;

        if (!System.IO.Directory.Exists(path + "/TestData"))
        {
            System.IO.Directory.CreateDirectory(path + "/TestData");
        }
            

        pageInfo = 1;
        pageLast = false;
        PageUpdate();

    }

    // Update is called once per frame
    void Update()
    {
        
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
            demographicQuestions.SetActive(false);
            questionnaireQuestions.SetActive(true);
            nextButton.SetActive(true);

            questionOneText.GetComponent<Text>().text = "Placeholder!";
            questionTwoText.GetComponent<Text>().text = "Placeholder!";
            questionThreeText.GetComponent<Text>().text = "Placeholder!";
            questionFourText.GetComponent<Text>().text = "Placeholder!";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 3)
        {
            questionOneText.GetComponent<Text>().text = "Placeholder!";
            questionTwoText.GetComponent<Text>().text = "Placeholder!";
            questionThreeText.GetComponent<Text>().text = "Placeholder!";
            questionFourText.GetComponent<Text>().text = "Placeholder!";

            ToggleOff();

            pageLock = true;

        }

        if (pageInfo == 4)
        {
            questionOneText.GetComponent<Text>().text = "Placeholder!";
            questionTwoText.GetComponent<Text>().text = "Placeholder!";
            questionThreeText.GetComponent<Text>().text = "Placeholder!";
            questionFourText.GetComponent<Text>().text = "Placeholder!";

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
                    sw.Write(ageInfo + " ;; " + genderInfo + " ;; " + gameHourInfo + " ;; " + favoriteGameOneInfo + " ;; " + favoriteGameTwoInfo + " ;; " + favoriteGameThreeInfo + " ;; ");

                    // Narrative Path
                    sw.Write(PlayerPrefs.GetString("PlayerType").ToString() + " ;; ");

                    // Player Behavior
                    sw.Write(PlayerPrefs.GetInt("Destruction").ToString() + " ;; " + PlayerPrefs.GetInt("Excitement").ToString() + " ;; " + PlayerPrefs.GetInt("Challenge").ToString() + " ;; " + PlayerPrefs.GetInt("Strategy").ToString() + " ;; " + PlayerPrefs.GetInt("Completion").ToString() + " ;; " + PlayerPrefs.GetInt("Power").ToString() + " ;; " + PlayerPrefs.GetInt("Fantasy").ToString() + " ;; " + PlayerPrefs.GetInt("Story").ToString() + " ;; " + PlayerPrefs.GetInt("Design").ToString() + " ;; " + PlayerPrefs.GetInt("Discovery").ToString() + " ;; ");

                    // Player Engagement: Round 1
                    sw.Write("test");

                    // Player Engagement: Round 2
                    sw.Write("test");

                    // Immersion
                    sw.Write("test");


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
            if(pageInfo == 1)
            {

            }
        }

        if (questionOneB.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionOneC.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionOneD.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionOneE.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        // Question 2

        if (questionTwoA.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionTwoB.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionTwoC.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionTwoD.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

            }
        }

        if (questionTwoE.GetComponent<Toggle>().isOn == true)
        {
            if (pageInfo == 1)
            {

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
