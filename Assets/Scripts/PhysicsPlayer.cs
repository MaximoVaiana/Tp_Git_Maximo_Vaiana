using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PhysicsPlayer : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 50f;
    public float jumpForce = 200f;
    public float maxSpeed = 10f;
    public bool canJump = true;
    public int itemsCollected = 0;
    public TextMeshProUGUI itemsCollectedText;
    public int totalItems = 0;
    public GameObject winPanel;
    public GameObject victory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        totalItems = GameObject.FindGameObjectsWithTag("item").Length;
        itemsCollectedText.text = "Capsulas: " + itemsCollected + "/" + totalItems;
        winPanel.SetActive(false);
        victory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0, jumpForce, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(new Vector3(0, 0, speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, 0, -speed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-speed, 0, 0));
        }


        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x * 0.99f, rb.linearVelocity.y, rb.linearVelocity.z * 0.99f);
        }


        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;

            rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
        }

        if (transform.position.y < -10f)
        {
            Destroy(rb.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag ("platform"))
        {
            canJump = true;
        }

        if (collision.gameObject.CompareTag("Victory"))
        {
            Destroy(gameObject);
            winPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("platform"))
        {
            canJump = false;
        }

        if (collision.gameObject.CompareTag("item"))
        {
            Destroy(collision.gameObject);


        }
    }

    public void CollectItem()
    {
        itemsCollected++;
        itemsCollectedText.text = "Capsulas: " + itemsCollected + "/" + totalItems;

        if (itemsCollected >= totalItems)
        {
            victory.SetActive(true);
        }
    }

}