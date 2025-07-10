using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
  
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Button play;
    [SerializeField] private Button options;
    [SerializeField] private Button exit;
    [SerializeField] private Button mainMenuGameOver;
    [SerializeField] private Button mainMenuOptions;
    [SerializeField] private Button mainMenuCredits;
    [SerializeField] private Button playAgain;
    [SerializeField] private Button credits;

     private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();  
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        inGamePanel.SetActive(false);
        pausePanel.SetActive(false);
        creditsPanel.SetActive(false);

        play.onClick.AddListener(PlayGameBtn);
        options.onClick.AddListener(OptionsBtn);
        exit.onClick.AddListener(ExitGame);
        mainMenuGameOver.onClick.AddListener(ReturnToMainMenu);
        mainMenuOptions.onClick.AddListener(ReturnToMainMenu);
        mainMenuCredits.onClick.AddListener(ReturnToMainMenu);
        playAgain.onClick.AddListener(PlayGameBtn);
        credits.onClick.AddListener(Credits);
        mainMenuGameOver.interactable = false;
        playAgain.interactable = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
        if (!gameManager.canPlay)
        {
            return;

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseUnpauseGame();
        }
    }

    private void Credits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    private IEnumerator ShortDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        mainMenuGameOver.interactable = true;
        playAgain.interactable = true;
    }


    private void ReturnToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        creditsPanel.SetActive(false);
        mainMenuGameOver.interactable = false;
        playAgain.interactable= false;
    }

    public void GameOver()
    {
        Time.timeScale = 10.0f;
        gameManager.canPlay = false;
        gameOverPanel.SetActive(true);
        StartCoroutine(ShortDelay());
    }
    private void PlayGameBtn()
    {
        Time.timeScale = 1.0f;
        mainMenuPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        inGamePanel.SetActive(true);
        gameManager.canPlay = true;
        gameManager.StartGame();
        playAgain.interactable = false;
        mainMenuGameOver.interactable = false;
    }

    private void PauseUnpauseGame()
    {
        if(Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            inGamePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            inGamePanel.SetActive(false);
        }
        
        

    }

    private void OptionsBtn()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
    private void Start()
    {
        RefreshUIScore(0);

    }
    public void RefreshUIScore(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
    public void RefreshUILives(int currentLives)
    {
        livesText.text = "LIVES: " + currentLives.ToString();
    }


}
