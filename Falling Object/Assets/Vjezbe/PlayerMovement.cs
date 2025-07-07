
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
            MovePlayerLeft();
        }
        
        if (Input.GetKey(KeyCode.D) && transform.position.x < 7)
        {
            MovePlayerRight();
        }
        
    }

    private void MovePlayerRight()
    {
        //rb.linearVelocity = speed * Time.deltaTime * Vector2.right;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.right *  speed, 10 * Time.deltaTime);
    }
    private void MovePlayerLeft()
    {
        // rb.linearVelocity = speed * Time.deltaTime * Vector2.left;
        rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.left * speed, 10 * Time.deltaTime);
    }
}
