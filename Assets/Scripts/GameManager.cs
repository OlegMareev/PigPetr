using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public AudioClip[] peaceMusic;
    public GameObject coinText;
   
    private AudioSource sceneMusic;
    private Text cointsText;
    private int countOfCoins;

    void Start()
    {  
        countOfCoins = PlayerPrefs.GetInt("CoinValue");
        cointsText = coinText.GetComponent<Text>();
        cointsText.text = countOfCoins.ToString();

        sceneMusic = GetComponent<AudioSource>();
        playNewSong();
    }

    void Update()
    {
        if (!sceneMusic.isPlaying)
        {
            playNewSong();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            restartScene();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuScene();
        }
    }
    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int getCoinValue() { return countOfCoins; }
    public void addCoins(int counter)
    {
        countOfCoins+= counter;
        cointsText.text = countOfCoins.ToString();
    }
    private void playNewSong()
    {
        int numOfSong = 0;
        if (peaceMusic.Length > 1)
            numOfSong = UnityEngine.Random.Range(0, peaceMusic.Length);
        if (sceneMusic.clip == peaceMusic[numOfSong])
            playNewSong();
        sceneMusic.clip = peaceMusic[numOfSong];
        if (sceneMusic.isActiveAndEnabled)
            if (PlayerPrefs.GetString("Music") == "On")
                sceneMusic.Play();
    }
    public void menuScene()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            startGame();
        }
        else
        {
            if(PlayerPrefs.GetString("LastScene")!= "Menu")
                PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("Menu");
        }

    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void startGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene"));
    }
    public void save()
    {
        PlayerPrefs.SetInt("CoinValue", countOfCoins);
    }
}
