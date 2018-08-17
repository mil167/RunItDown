using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public string mainmenu;
    
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("mainmenu");
        //Application.LoadLevel(mainmenu);
    }
}
