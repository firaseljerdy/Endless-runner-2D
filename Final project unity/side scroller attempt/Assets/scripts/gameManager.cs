using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameManager : MonoBehaviour {

    public Transform platformGenerator;

    public playerController player;

    public DeathMenu endScreen;

    public PauseMenu pause;

    public AudioSource mainThemeMusic;

    public AudioSource click;

    public bool powerupReset;

    

    private Vector3 platformStartPoint;

    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private scoreManager score;


    private bool isGameRunning;

    void Start()
    {
        click.Play();

        platformStartPoint = platformGenerator.position;

        playerStartPoint = player.transform.position;

        score = FindObjectOfType<scoreManager>();

        isGameRunning = true;

        mainThemeMusic.Play();

       
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && isGameRunning)
        {

            pause.PauseGame();
            isGameRunning = false;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && !isGameRunning)
        {

            pause.ResumeGame();
            isGameRunning = true;
        }
    }

    public void RestartGame()
    {

        click.Play();

        score.scoreIncreasing = false;

        player.gameObject.SetActive(false);

        endScreen.gameObject.SetActive(true);

        isGameRunning = false;

    }

    public void Reset_()
    {
        click.Play();

        endScreen.gameObject.SetActive(false);

        platformList = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platformList.Length; i++)
        {

            platformList[i].gameObject.SetActive(false);

        }

        player.transform.position = playerStartPoint;

        platformGenerator.transform.position = platformStartPoint;

        player.gameObject.SetActive(true);

        score.score_count = 0;

        score.scoreIncreasing = true;

        powerupReset = true;

    }

}
