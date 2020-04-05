using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{

    public Text timerText;
    public Text infectedCounter;
    public GameObject gameEnd;
    public Text timeScore;
    public Text score;
    public Button homeButton;

    private float seconds = 0;
    private float totalPeople = 0;

    void Start()
    {
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));

        totalPeople = GameObject.FindGameObjectsWithTag("Person").Length - 1;

        ControlVariable.Ins.TotalInfected = 0;

        seconds = ControlVariable.Ins.TimerInSeconds;

        StartCoroutine(UpdateTime());
    }

    private IEnumerator UpdateTime()
    {
        timerText.text = "0 : " + seconds;
        while (seconds > 0)
        {
            yield return new WaitForSeconds(1f);

            infectedCounter.text = "Infected : " + ControlVariable.Ins.TotalInfected + " / " + totalPeople;


            if ((seconds <= 0) || totalPeople == ControlVariable.Ins.TotalInfected)
            {
                Debug.Log("Time Up");
                break;
            }
            else
            {
                seconds -= 1;
            }

            if(seconds > -1)
                timerText.text = "0 : " + seconds;
        }

        yield return new WaitForSeconds(1f);
        ShowGameEnd();
        StopCoroutine(UpdateTime());
    }

    private void ShowGameEnd()
    {
        timeScore.text = ControlVariable.Ins.TimerInSeconds + " s";
        score.text = ((int)(100 - ((ControlVariable.Ins.TotalInfected / totalPeople) * 100))) + "";
        gameEnd.SetActive(true);
    }
}
