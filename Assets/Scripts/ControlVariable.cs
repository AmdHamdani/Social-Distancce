using UnityEngine;

[CreateAssetMenu(fileName = "MainControlVariable", menuName = "Control/MainControlVariable")]
public class ControlVariable : ScriptableObject
{

    public float InfectionTime;

    public static ControlVariable Instance
    {
        get
        {
            return Resources.Load<ControlVariable>("MainControlVariable");
        }
    }

}
