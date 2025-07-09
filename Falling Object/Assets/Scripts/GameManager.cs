using System.Collections;

using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField] private FallingObject[] prefabs;
    [SerializeField] private float rangeXMin = -3.1f;
    [SerializeField] private float rangeXMax = 3.1f;

    [SerializeField] private UIManager uiManager;
    private int score = 0;
    private int maxLives = 3;
    private int currentLives = 0;
    private int livesCounter = 0;
    public bool canPlay = false;


    private int RandomIndex()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        return randomIndex;
    }

    private void Start()
    {

        currentLives = maxLives;
        uiManager.RefreshUILives(currentLives);


    }

    private void ResetGame()
    {
        score = 0;
        currentLives = maxLives;
        livesCounter = 0;
        uiManager.RefreshUILives(currentLives);
        uiManager.RefreshUIScore(score);
    }

    public void StartGame()
    {
        ResetGame();
        if (canPlay)
        {
            StartCoroutine(StartSpawns());
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        uiManager.RefreshUIScore(score);

    }

    public void AddLivesCounter()
    {
        livesCounter++;
        Debug.Log("add counter");
        if (livesCounter >= 10)
        {
            AddLife();
            livesCounter = 0;
        }
    }
    public void SubstractLivesCounter()
    {
        livesCounter--;
        Debug.Log("sub counter");
        if (livesCounter <= 0) { livesCounter = 0; }
    }

    public void AddLife()
    {
        currentLives++;
        if (currentLives >= maxLives)
        {
            currentLives = maxLives;
        }
        uiManager.RefreshUILives(currentLives);
    }

    public void ReduceLife()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            currentLives = 0;
            uiManager.GameOver();
        }
        uiManager.RefreshUILives(currentLives);
    }


    private IEnumerator StartSpawns()
    {
        yield return new WaitForSeconds(1);
        Instantiate();
        if (canPlay) { StartCoroutine(StartSpawns()); }


    }
    private float RandomDistanceX()
    {
        return Random.Range(rangeXMin, rangeXMax);
    }
    private void Instantiate()
    {

        Instantiate(prefabs[RandomIndex()], new Vector3(RandomDistanceX(), 6f, -6f), Quaternion.identity);
    }

}
