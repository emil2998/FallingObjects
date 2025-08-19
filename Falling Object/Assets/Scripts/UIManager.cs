using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
  
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text livesText;
   
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject pausePanel; 
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Button mainMenuGameOver;  
    [SerializeField] private Button playAgain;  

     private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();                  
        mainMenuGameOver.onClick.AddListener(ReturnToMainMenu);     
    }

    private void Start()
    {
        inGamePanel.SetActive(false);
        pausePanel.SetActive(false);

        mainMenuGameOver.interactable = false;
        playAgain.interactable = false;

        RefreshUIScore(0);
        PlayGame();
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

    private IEnumerator ShortDelay()
    {
        yield return new WaitForSecondsRealtime(2);
        mainMenuGameOver.interactable = true;
        playAgain.interactable = true;
    }

    private void ReturnToMainMenu()
    {
        gameOverPanel.SetActive(false);
        mainMenuGameOver.interactable = false;
        playAgain.interactable= false;
        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver()
    {
        Time.timeScale = 10.0f;
        gameManager.canPlay = false;
        gameOverPanel.SetActive(true);
        StartCoroutine(ShortDelay());
    }

    private void PlayGame()
    {
        Time.timeScale = 1.0f;
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
    
    public void RefreshUIScore(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
    public void RefreshUILives(int currentLives)
    {
        livesText.text = "LIVES: " + currentLives.ToString();
    }
}
