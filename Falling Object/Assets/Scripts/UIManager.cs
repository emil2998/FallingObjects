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

    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Button play;
    [SerializeField] private Button options;
    [SerializeField] private Button exit;
    [SerializeField] private Button mainMenuGameOver;
    [SerializeField] private Button playAgain;

     private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();  
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        inGamePanel.SetActive(false);
        pausePanel.SetActive(false);

        play.onClick.AddListener(PlayGameBtn);
        options.onClick.AddListener(OptionsBtn);
        exit.onClick.AddListener(ExitGame);
        mainMenuGameOver.onClick.AddListener(ReturnToMainMenu);
        playAgain.onClick.AddListener(PlayGameBtn);

        mainMenuGameOver.interactable = false;
        playAgain.interactable = false;

    }

    private void Update()
    {
        if (!gameManager.canPlay)
        {
            return;

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseUnpauseGame();
        }
    }

    private IEnumerator ShortDelay()
    {
        yield return new WaitForSecondsRealtime(1);
        mainMenuGameOver.interactable = true;
        playAgain.interactable = true;
    }


    private void ReturnToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);    
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
        scoreText.text = "Score: " + score.ToString();
    }
    public void RefreshUILives(int currentLives)
    {
        livesText.text = "Lives: " + currentLives.ToString();
    }


}
