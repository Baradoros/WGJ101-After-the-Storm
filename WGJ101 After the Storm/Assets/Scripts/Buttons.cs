using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelStart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Main_Test", LoadSceneMode.Single);
    }
}
