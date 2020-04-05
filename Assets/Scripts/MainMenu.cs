using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button startButton;
    public GameObject instructionOne;
    public GameObject instructionTwo;
    public Button nextInstruction;
    public Button playGame;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(() => instructionOne.SetActive(true));
        nextInstruction.onClick.AddListener(() => instructionTwo.SetActive(true));
        playGame.onClick.AddListener(() => SceneManager.LoadScene("Gameplay"));
    }

}
