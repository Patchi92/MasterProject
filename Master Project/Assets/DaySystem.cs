using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour {

    IEnumerator DayAndNightSystem()
    {
        RenderSettings.ambientIntensity = 0.9f;
        yield return new WaitForSeconds(45f);
        RenderSettings.ambientIntensity = 0.85f;
        yield return new WaitForSeconds(45f);
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


    }
}
