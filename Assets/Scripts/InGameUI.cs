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

    private float interval = 0;
    private float totalPeople = 0;

    void Start()
    {
        homeButton.onClick.AddListener(() => SceneManager.LoadScene("Menu"));

        totalPeople = GameObject.FindGameObjectsWithTag("Person").Length - 1;

        ControlVariable.Ins.TotalInfected = 0;

        interval = ControlVariable.Ins.TimerInMinutes;

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

            if ((second <= 0 & interval <= 0) || totalPeople == ControlVariable.Ins.TotalInfected)
            {
                yield return new WaitForSeconds(1f);
                ShowGameEnd();
                StopCoroutine(UpdateTime());
                break;
            }
            else
            {
                second -= 1;
            }

            timerText.text = interval + " : " + second;
            infectedCounter.text = "Infected : " + ControlVariable.Ins.TotalInfected + " / " + totalPeople;
        }
    }

    private void ShowGameEnd()
    {
        timeScore.text = ControlVariable.Ins.TimerInMinutes * 60 + " s";
        score.text = (100 - ((ControlVariable.Ins.TotalInfected / totalPeople) * 100)) + "";
        gameEnd.SetActive(true);
    }
}
