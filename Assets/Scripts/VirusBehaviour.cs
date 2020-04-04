using System.Collections.Generic;
using UnityEngine;

public class VirusBehaviour : MonoBehaviour
{

    public InfectionState infection;

    private float interval = 0;
    private List<Collider2D> nearestAgent = new List<Collider2D>();

    private void Start()
    {
        if (infection == InfectionState.Infected)
        {
            ShowIndicator();
        }
    }

    public void StartInfection(float time = 3f)
    {
        if (infection == InfectionState.Infected)
            return;

        infection = InfectionState.Infecting;
        interval = ControlVariable.Instance.InfectionTime;
    }

    public void StopInfection()
    {
        if (infection == InfectionState.Infected)
            return;

        infection = InfectionState.None;
        interval = ControlVariable.Instance.InfectionTime;
    }

    private void Update()
    {
        if (infection == InfectionState.Infecting)
        {
            interval -= Time.deltaTime;

            if (interval <= 0)
            {
                infection = InfectionState.Infected;
                ShowIndicator();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nearestAgent.Add(collision);
        Debug.Log("Add " + collision.gameObject.name);

        var virus = collision.gameObject.GetComponent<VirusBehaviour>();

        if (virus == null)
        {
            virus = collision.gameObject.AddComponent<VirusBehaviour>();
        }

        virus.StartInfection();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        nearestAgent.Remove(collision);
        var virus = collision.GetComponent<VirusBehaviour>();

        Debug.Log("Remove " + collision.gameObject.name);

        if (virus != null)
        {
            virus.StopInfection();
        }
    }
    private void ShowIndicator()
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }

}
