using TMPro;
using UnityEngine;

public class Vjezba1 : MonoBehaviour
{
     private int score = 0;
    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = score.ToString();
    }
    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

}

