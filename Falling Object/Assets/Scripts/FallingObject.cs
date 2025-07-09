using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private int scoreAmount;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player))
        {
            player.ScoreChange(scoreAmount);
            if (scoreAmount < 0) { 
                player.LoseLiveCounter();
            }
            else if (scoreAmount>0)
            {
                player.LivesCounterUpdate();
            }
                Destroy(this.gameObject);
        }

        if(other.gameObject.TryGetComponent(out OutOfBoundry bottom))
        {
            if (scoreAmount < 0)
            {
                Destroy(this.gameObject);
            }
            else if (scoreAmount > 0)
            {
                bottom.LoseLive();
                Destroy(this.gameObject);
            }
                
        }
    }
}
