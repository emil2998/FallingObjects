using UnityEngine;

public class PlayerMovementVjezba : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 20f;

    public float playerHP = 100;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.linearVelocity = Vector3.zero;
      
        if (Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity = Vector3.forward * speed;       
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.linearVelocity = Vector3.back * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = Vector3.right * speed;
        }
    }
}
