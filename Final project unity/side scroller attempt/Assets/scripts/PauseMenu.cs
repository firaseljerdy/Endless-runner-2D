using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {


    public AudioSource click;

    public void RestartGame()
    {
        click.Play();

        gameObject.SetActive(false);

        Time.timeScale = 1f;

        FindObjectOfType<gameManager>().Reset_();
        

    }

    public void QuitToMainMenu()
    {
        click.Play();

        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void PauseGame()
    {
        click.Play();

        gameObject.SetActive(true);

        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {
        click.Play();

        gameObject.SetActive(false);

        Time.timeScale = 1f;

    }

}
