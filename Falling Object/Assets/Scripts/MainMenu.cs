
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject loadingPanel;

    [SerializeField] private Button mainMenuOptions;
    [SerializeField] private Button mainMenuCredits;

    [SerializeField] private Button play;
    [SerializeField] private Button options;
    [SerializeField] private Button credits;
    [SerializeField] private Button exit;

    [SerializeField] private TMP_Text infoText;
    [SerializeField] private Image progressBar;

    [SerializeField] private float loadingTimeValue = 5f;

    private float timer;
    private bool canStartLoad;
    private bool readyToContinue;

    private AsyncOperation asyncOperation;

    private void Start()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        loadingPanel.SetActive(false);
        timer = 0;
        canStartLoad = false;
        readyToContinue = false;
    }
    private void OnEnable()
    {
        play.onClick.AddListener(PlayGameBtn);
        options.onClick.AddListener(OptionsBtn);
        credits.onClick.AddListener(Credits);
        exit.onClick.AddListener(ExitGame);

        mainMenuOptions.onClick.AddListener(ReturnToMainMenu);
        mainMenuCredits.onClick.AddListener(ReturnToMainMenu);
    }

    private void Credits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    private void ReturnToMainMenu()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }


    private void PlayGameBtn()
    {
        mainMenuPanel.SetActive(false);
        loadingPanel.SetActive(true);
        canStartLoad = true;

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;


        asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;


        while (!asyncOperation.isDone)
        {
            if(asyncOperation.progress >= 0.9f)
            {
               // asyncOperation.allowSceneActivation = true;
                readyToContinue = true;
            
            }        
            yield return null;
        }
    }

    private void Update()
    {
        if (timer < loadingTimeValue && canStartLoad)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / loadingTimeValue);
            progressBar.fillAmount = progress;
            infoText.text = "Loading... " + Mathf.Round(progress * 100f).ToString("F0") + " %";
        }

        if (readyToContinue && timer >= loadingTimeValue)
        {
            progressBar.fillAmount = 1f;
            infoText.text = "Press the space bar to continue";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                asyncOperation.allowSceneActivation = true;
            }
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



}
