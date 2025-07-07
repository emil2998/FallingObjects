using UnityEngine;

public class Vjezba1 : MonoBehaviour
{
    [SerializeField] private float score = 0;

    public void AddScore(float amount)
    {
        score += amount;
    }

}

