using System.Collections.Generic;
using UnityEngine;

public class VirusBehaviour : MonoBehaviour
{

    public InfectionState infection;

    private float interval = 0;
    private List<Collider2D> nearestAgent = new List<Collider2D>();
    private SpriteRenderer virusIcon;

    private void Start()
    {
        SetVirusIcon();

        if (infection == InfectionState.Infected)
        {
            ShowIndicator();
        }
    }

    public void StartInfection(float time = 3f)
    {
        if (infection == InfectionState.Infected)
            return;

        SetVirusIcon();

        infection = InfectionState.Infecting;
        interval = ControlVariable.Ins.InfectionTime;
    }

    public void StopInfection()
    {
        if (infection == InfectionState.Infected)
            return;

        infection = InfectionState.None;
        interval = ControlVariable.Ins.InfectionTime;
    }

    private void Update()
    {
        if (infection == InfectionState.Infecting)
        {
            interval -= Time.deltaTime;

            if (interval <= 0)
            {
                infection = InfectionState.Infected;
                ControlVariable.Ins.TotalInfected += 1;
                ShowIndicator();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nearestAgent.Add(collision);

        var virus = collision.gameObject.GetComponent<VirusBehaviour>();

        if (virus == null)
        {
            virus = collision.gameObject.AddComponent<VirusBehaviour>();
        }

        virus.StartInfection();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach (var person in nearestAgent)
        {
            var virus = GetComponent<VirusBehaviour>();
            if (virus == null)
            {
                virus = person.gameObject.AddComponent<VirusBehaviour>();
                virus.StartInfection();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearestAgent.Remove(collision);
        var virus = collision.GetComponent<VirusBehaviour>();

        if (virus != null)
        {
            virus.StopInfection();
        }
    }

    private void SetVirusIcon()
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>(true);
        virusIcon = sprites[sprites.Length - 1];
    }

    private void ShowIndicator()
    {
        virusIcon.enabled = true;

    }

}
