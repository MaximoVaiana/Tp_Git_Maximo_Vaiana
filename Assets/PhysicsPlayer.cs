using UnityEngine;
using UnityEngine.Rendering;

public class PhysicsPlayer : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 50f;
    public float jumpForce = 300f;
    public bool canJump = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0, jumpForce, 0);

            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(0, 0, speed);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(0, 0, -speed);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(speed, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-speed, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("platform"))
        {
            canJump = true;
        }
    }
}