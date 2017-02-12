using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialog", order = 1)]
public class Dialog : ScriptableObject
{

    

    [HideInInspector]
    public int DialogLength;

    public string[] Name;

    [TextArea(3, 5)]
    public string[] Text;

    public float[] Wait;

    public string[] Sound;

    public bool Choice;


    

}

