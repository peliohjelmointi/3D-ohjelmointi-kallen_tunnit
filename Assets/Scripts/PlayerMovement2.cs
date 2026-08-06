using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement2 : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float turnSpeed = 180f; //astetta sekunnissa

    [SerializeField] PlayerMovementMouseRotation playerMovementMouseRotation;
    CharacterController controller;
    Vector2 moveInput; //kun liikutaan, napataan x ja y -arvot tahan
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    public void OnLook(InputValue value)
    {
        playerMovementMouseRotation.Look(value);
    }

    public void OnMove(InputValue value) //pitää olla public, jotta Player Input löytää
    {
        moveInput = value.Get<Vector2>(); //luetaan pelaajan WASD-liikkestä x ja y -koordinaatit        
    }

    void Update()
    {
        //// ns. Tank Controls
        //// kääntyminen
        //if (moveInput.y>=0) //eteenpäin
        //    transform.Rotate(Vector3.up, moveInput.x * turnSpeed * Time.deltaTime);
        //else //taaksepäin
        //    transform.Rotate(Vector3.up, -moveInput.x * turnSpeed * Time.deltaTime);

        //liikkuminen eteen/taakse
        //Vector3 movement = transform.forward * moveInput.y;
        Vector3 movement = transform.right * moveInput.x + transform.forward * moveInput.y;

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}
