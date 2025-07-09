using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int scoreAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Vjezba1 cube))
        {
            cube.AddScore(scoreAmount);
            Destroy(this.gameObject);
        }
    }
}
