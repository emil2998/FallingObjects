

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private readonly float speed = 30f;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioManager audioManager;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = Vector3.zero;
        if (!gameManager.canPlay)
        {
            return;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -7)
        {
            MovePlayer(Vector2.left);
        }
        
        if (Input.GetKey(KeyCode.D) && transform.position.x < 7)
        {
            MovePlayer(Vector2.right);
        }
        
    }

    public void LoseLiveByPickingUpWrongItem() {

        gameManager.ReduceLife();
    }

    public void PlayExplosionSound()
    {
        audioManager.PlayExplosion();
    }

    public void LivesCounterUpdate()
    {
        gameManager.AddLivesCounter();
    }
    public void LoseLiveCounter()
    {
        gameManager.SubstractLivesCounter();
    }

    public void ScoreChange(int amount)
    {
        gameManager.AddScore(amount);
    }
    private void MovePlayer(Vector2 direction)
    {
        direction.Normalize();
        Vector2 targetVelocity = direction * speed;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, 10 * Time.deltaTime);
    }
}
