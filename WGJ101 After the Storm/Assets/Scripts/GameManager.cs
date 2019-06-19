using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject janitor;
    private CheckBarCleanliness janitorScript;
    [SerializeField] private float time = 10;
    private bool gameWon = false;
    private bool gameOver = false;

    public bool levelStarted = false;
    public float setTime;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    // Start is called before the first frame update
    void Start()
    {
        janitor = GameObject.FindGameObjectWithTag("Janitor");
        janitorScript = janitor.GetComponent<CheckBarCleanliness>();
        time = setTime;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Invoke("LevelStarted", 5.0f);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameWin();
        Timer();
    }

    void CheckGameWin()
    {
        if(janitorScript.clutterCount == 0 && janitorScript.drunkCount == 0 && gameOver == false && levelStarted == true)
        {
            Debug.Log("You win!");
            gameWon = true;
            winCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        if(gameOver == true)
        {
            Debug.Log("You lose.");
            loseCanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }

    void Timer()
    {
        if (time >= 0 && gameWon == false)
        {
            time -= Time.deltaTime;
        }
        if(time <= 0)
        {
            gameOver = true;
        }
    }

    void LevelStarted()
    {
        levelStarted = true;
    }
}
