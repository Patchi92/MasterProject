using UnityEngine;

[CreateAssetMenu(fileName = "Choice", menuName = "Choice", order = 2)]
public class Choice : ScriptableObject
{
    public string Name;

    [TextArea(3, 5)]
    public string[] choice;

    [TextArea(3, 5)]
    public string[] response;

    public float[] wait;

    public bool simpleQuestion;

}
