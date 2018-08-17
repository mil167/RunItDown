using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public string mainmenu;
    public GameObject pm;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pm.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pm.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pm.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        pm.SetActive(false);
        SceneManager.LoadScene("mainmenu");
        //Application.LoadLevel(mainmenu);
    }
}
