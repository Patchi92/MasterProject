using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSelection : MonoBehaviour
{

    public Dialog[] dialogs;
    UiSystem UI;
    GameObject dialogBox;
    GameObject dialogText;

    // Narrative
    GameObject narrativeSystem;

    // Dialog System

    int indexCount;
    float duration;
    bool isSkipped;
    float SpeakingTime;
    bool isSpeaking;


    void Awake()
    {
        narrativeSystem = GameObject.Find("NarrativeSystem");

        UI = transform.parent.gameObject.GetComponent<UiSystem>();
        dialogBox = transform.FindChild("DialogBox").gameObject;
        dialogText = dialogBox.transform.FindChild("Text").gameObject;
    }

    // Use this for initialization
    void Start()
    {

        indexCount = 0;
        isSkipped = false;
        isSpeaking = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (UI.dialog)
        {
            dialogBox.SetActive(true);
        }
        else
        {
            dialogBox.SetActive(false);
        }
    }


    public IEnumerator DialogSystem(int v)
    {
        Dialog d = dialogs[v];
        d.DialogLength = d.Name.Length;
        UI.dialog = true;

        for (int i = 0; i < d.DialogLength; i++)
        {



            indexCount = i;

            dialogText.GetComponent<Text>().text = d.Name[i] + ":" + "\n" + "\n" + d.Text[i];

            //Sound and stuff



            SpeakingTime = d.Wait[i];

            while (!isSkipped && SpeakingTime > 0)
            {
                SpeakingTime -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            isSkipped = false;


            //if (d.Name[i] == "Player")
            //{
            //    indexCount = i;

            //    dialogText.GetComponent<Text>().text = "Player:" + "\n" + "\n" + d.Text[i];
                
            //    //Sound and stuff
                


            //    SpeakingTime = d.Wait[i];

            //    while (!isSkipped && SpeakingTime > 0)
            //    {
            //        SpeakingTime -= Time.deltaTime;
            //        yield return new WaitForEndOfFrame();
            //    }
            //    isSkipped = false;

            //}



            //if (d.Name[i] == "QuestGiver")
            //{
            //    indexCount = i;

            //    dialogText.GetComponent<Text>().text = "QuestGiver:" + "\n" + "\n" + d.Text[i];

            //    //Sound and stuff
                


            //    SpeakingTime = d.Wait[i];

            //    while (!isSkipped && SpeakingTime > 0)
            //    {
            //        SpeakingTime -= Time.deltaTime;
            //        yield return new WaitForEndOfFrame();
            //    }
            //    isSkipped = false;

            //}


        }

        dialogText.GetComponent<Text>().text = "";
        UI.dialog = false;

        if(PlayerPrefs.GetString("Version") != "Complex")
        {
            if (d.Choice)
            {
                UI.choice = true;
            }
            else
            {
                UI.UnlockPlayer();
            }
        } else
        {
            narrativeSystem.GetComponent<NarrativeSystem>().NarrativeFeedback(0);
            UI.UnlockPlayer();
        }


      



    }

    void StopDialog()
    {
        StopCoroutine("DialogSystem");
        UI.dialog = false;
    }

    public void SkipDialog()
    {
        isSkipped = true;
    }

}
