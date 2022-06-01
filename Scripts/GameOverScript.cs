using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;

    public GameObject ScoreLive;
    public GameObject TimeLive;


    // Start is called before the first frame update
    void Start()
    {
        ScoreLive.gameObject.SetActive(false);
        TimeLive.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score " + score.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Minesweeper");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

}
