using UnityEngine;

[CreateAssetMenu(fileName = "Choice", menuName = "Choice", order = 2)]
public class Choice : ScriptableObject
{

    [TextArea(3, 5)]
    public string[] Text;


}
