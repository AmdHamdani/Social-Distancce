using UnityEngine;

[CreateAssetMenu(fileName = "MainControlVariable", menuName = "Control/MainControlVariable")]
public class ControlVariable : ScriptableObject
{

    public float MinInfectionTime;
    public float MaxInfectionTime;
    public float TimerInMinutes;
    public float TotalInfected;

    public float InfectionTime
    {
        get
        {
            return Random.Range(MinInfectionTime, MaxInfectionTime);
        }
    }

    public static ControlVariable Instance
    {
        get
        {
            return Resources.Load<ControlVariable>("MainControlVariable");
        }
    }

}
