using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionCheck : MonoBehaviour {

    public GameObject questionToggleOne;
    public GameObject questionToggleTwo;
    public GameObject questionToggleThree;
    public GameObject questionToggleFour;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {





	}

    public void UpdateToggle()
    {
        questionToggleOne.GetComponent<Toggle>().isOn = false;
        questionToggleTwo.GetComponent<Toggle>().isOn = false;
        questionToggleThree.GetComponent<Toggle>().isOn = false;
        questionToggleFour.GetComponent<Toggle>().isOn = false;
    }
}
