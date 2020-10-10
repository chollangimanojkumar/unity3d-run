using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void replay()
    {
        SceneManager.LoadScene("Level");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
