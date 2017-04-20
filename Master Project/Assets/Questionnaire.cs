using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject questionOne;
    public GameObject questionTwo;
    public GameObject questionThree;
    public GameObject questionFour;
    public GameObject nextButton;

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
        }

        if (pageInfo == 2)
        {
            pageLock = true;
            demographicQuestions.SetActive(false);
            questionnaireQuestions.SetActive(true);

        }

        if (pageInfo == 3)
        {
            pageLock = true;

        }

        if (pageInfo == 4)
        {
            pageLock = true;

        }

        if (pageInfo == 5)
        {

            thanksPlaying.SetActive(true);
            nextButton.GetComponent<Text>().text = "Quit";
        }

        if (pageInfo == 6)
        {
            Application.Quit();

        }
    }

    public void NextPage()
    {

        if(pageInfo == 1)
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
        } else {


        }
       

        if(!pageLock)
        {
            if(pageLast == true)
            {

            }

            ++pageInfo;
            PageUpdate();
        }
    }

}
