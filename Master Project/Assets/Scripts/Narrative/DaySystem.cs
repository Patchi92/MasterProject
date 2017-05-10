using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour {

    public GameObject question;
    GameObject player;
    public GameObject nextPos;


    IEnumerator DayAndNightSystem()
    {
        RenderSettings.ambientIntensity = 0.8f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.75f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.7f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.65f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.6f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.55f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.5f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.45f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.4f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.35f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.3f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.25f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.2f;

        player = GameObject.Find("Player");

        //question.SetActive(true);
        player.transform.position = nextPos.transform.position;
        // player.SetActive(false);

        //TEMP
        GameObject.Find("NarrativeSystem").GetComponent<NarrativeSystem>().ChapterSelect(3);


    }
}
