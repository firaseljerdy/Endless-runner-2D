using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public AudioSource menuMusic;

    public AudioSource click;

    void Start()
    {
        menuMusic.Play();
    }

    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        click.Play();


    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
        
    }

}
