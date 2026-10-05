using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class Capsula : MonoBehaviour
{
    public int counter = 0;
    public float speed = 5f;
    public Vector3 startPosition;
    public Vector3 moveDirection;

    public CharacterController characterController;

    float gravity = -9.81f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = startPosition;
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
            MoveCharacter(new Vector3(0, 0, 1));
        }

        if(Input.GetKey(KeyCode.S))
        {
            //transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
            MoveCharacter(new Vector3(0, 0, -1));
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            MoveCharacter(new Vector3(-1, 0, 0));
        }

        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            MoveCharacter(new Vector3(1, 0, 0));
        }


        if (characterController.isGrounded == false)
        {
            characterController.Move(new Vector3(0, gravity, 0) * Time.deltaTime);
        }
    }

    private void MoveCharacter(Vector3 direction)
    {
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
    
}
