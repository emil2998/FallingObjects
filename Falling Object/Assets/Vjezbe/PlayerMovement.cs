using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 5000f;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rb.linearVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            MovePlayerLeft();
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            MovePlayerRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MovePlayerLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MovePlayerRight();
        }
    }

    private void MovePlayerRight()
    {
        rb.linearVelocity = speed * Time.deltaTime * Vector2.right;
    }
    private void MovePlayerLeft()
    {
        rb.linearVelocity = speed * Time.deltaTime * Vector2.left;
    }
}
