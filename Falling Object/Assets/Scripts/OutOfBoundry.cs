using UnityEngine;

public class OutOfBoundry : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public void LoseLive()
    {
        gameManager.ReduceLife();
    }
}
