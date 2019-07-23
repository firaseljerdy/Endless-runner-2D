using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {


    public AudioSource click;
  
    public void RestartGame()
    {
        click.Play();

        FindObjectOfType<gameManager>().Reset_();

    }

    public void QuitToMainMenu()
    {

        click.Play();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    
}
