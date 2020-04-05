using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{

    public Text timerText;
    public Text infectedCounter;

    private float interval = 0;
    private float totalPeople = 0;

    // Start is called before the first frame update
    void Start()
    {
        totalPeople = GameObject.FindGameObjectsWithTag("Person").Length - 1;

        ControlVariable.Instance.TotalInfected = 0;

        interval = ControlVariable.Instance.TimerInMinutes;

        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        interval -= 1;
        var second = 59;
        timerText.text = interval + " : " + second;
        while (interval <= 0)
        {
            yield return new WaitForSeconds(1f);

            if (second <= 0)
            {
                second = 59;
                interval -= 1;
            }

            if (second <= 0 & interval <= 0)
            {
                Debug.Log("Time Up");
                StopCoroutine(UpdateTime());
            }
            else
            {
                second -= 1;
            }

            timerText.text = interval + " : " + second;
            infectedCounter.text = "Infected : " + ControlVariable.Instance.TotalInfected + " / " + totalPeople;
        }
    }

}
