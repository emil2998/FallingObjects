

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 75f;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A) && transform.position.x > -7)
        {
            MovePlayer(Vector2.left);
        }
        
        if (Input.GetKey(KeyCode.D) && transform.position.x < 7)
        {
            MovePlayer(Vector2.right);
        }
        
    }

    private void MovePlayer(Vector2 direction)
    {
        direction.Normalize();
        Vector2 targetVelocity = direction * speed;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, targetVelocity, 10 * Time.deltaTime);
    }
}
