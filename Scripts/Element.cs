using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    // Is this a mine?
    public bool mine;

    // Different Textures
    public Sprite[] emptyTextures;
    public Sprite mineTexture;  

    public GameOverScript GameOverScript;
    public TimerScript TimerScript;
    public GameObject WinScreen;
    public GameObject LooseScreen;
    public GameObject defaultsAll;

    private float z;

    // Use this for initialization
    void Start()
    {
        ScoreScript.scoreValue = 0;
        
        if(DifficultyScript.a)
        {
            z = 0.25f;
        }
        else if(DifficultyScript.b)
        {
            z = 0.15f;
        }
        else if(DifficultyScript.c)
        {
            z = 0.05f;
        }
        // Randomly decide if it's a mine or not
        mine = Random.value < z;

        // Register in Grid
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        PlayField.elements[x, y] = this;
    }
    private void Update()
    {
        if (TimerScript.timeZero)
        {
            StartCoroutine(Task(1));
            LooseScreen.SetActive(true);
            print("Time's UP");
        }
    }
    // Load another texture
    public void loadTexture(int adjacentCount)
    {
            if (mine)
            {
                GetComponent<SpriteRenderer>().sprite = mineTexture;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
            }
    }
    // Is it still covered?
    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {
        
            // It's a mine
            if (mine)
            {
                // uncover all mines

                PlayField.uncoverMines();
                StartCoroutine(Task(1));
                LooseScreen.SetActive(true);

                // game over
                print("you lose");
            }
            // It's not a mine
            else if (isCovered())
            {
                TimerScript.timeReset = true;
                // show adjacent mine number
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                loadTexture(PlayField.adjacentMines(x, y));

                // uncover area without mines
                PlayField.FFuncover(x, y, new bool[PlayField.w, PlayField.h]);


                // find out if the game was won now
                if (PlayField.isFinished())
                {
                    
                    WinScreen.SetActive(true);
                    StartCoroutine(Task(1));
                    print("you win");
                }
            }
        
    }

    IEnumerator Task(int a)
    {
        int z = ScoreScript.scoreValue;
        TimerScript.isTimer = false;
        yield return new WaitForSeconds(a);
        WinScreen.SetActive(false);
        LooseScreen.SetActive(false);
        defaultsAll.gameObject.SetActive(false);

        GameOverScript.Setup(z);
    }
}
