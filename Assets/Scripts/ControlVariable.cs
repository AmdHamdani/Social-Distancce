using UnityEngine;

[CreateAssetMenu(fileName = "MainControlVariable", menuName = "Control/MainControlVariable")]
public class ControlVariable : ScriptableObject
{

    [Header("Infection Speed")]
    [SerializeField] private float minInfectionTime;
    [SerializeField] private float maxInfectionTime;
    [Header("Person Speed")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [Header("Game Timer")]
    [SerializeField] private float timerInSeconds;
    [HideInInspector]
    [SerializeField] private float totalInfected;

    public float PersonSpeed
    {
        get
        {
            return Random.Range(minSpeed, maxSpeed);
        }
    }

    public float InfectionTime
    {
        get
        {
            return Random.Range(minInfectionTime, maxInfectionTime);
        }
    }

    public static ControlVariable Ins
    {
        get
        {
            return Resources.Load<ControlVariable>("MainControlVariable");
        }
    }

    public float TimerInSeconds { get => timerInSeconds; }

    public float TotalInfected { get => totalInfected; set => totalInfected = value; }
}
