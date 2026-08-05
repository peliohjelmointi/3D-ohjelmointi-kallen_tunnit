using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] float moveSpeed = 5f;
    CharacterController controller;
    Vector2 moveInput; //kun liikutaan, napataan x ja y -arvot tahan

    float gravity = -9.81f;
    float verticalVelocity;


    void Awake(){               
        controller = GetComponent<CharacterController>();
    }

    public void OnMove(InputValue value) //pitää olla public, jotta Player Input löytää
    {
        moveInput = value.Get<Vector2>(); //luetaan pelaajan WASD-liikkestä x ja y -koordinaatit
        //print(moveInput);
    }

    private void Update()
    {   //tässä  versiossa liikutaan vain koordinaateissa world spacessa:
        //Vector3 movement = new Vector3(-moveInput.y,0f,moveInput.x); // Huom. sijoitetaan X ja Z

        // muutetaan liikkuminen world spacesta local spaceen
        // = pelaajaa liikutetaan eteenpäin pelaasta, ei koordinaateista

        //tapa 1 ekspliittisesti:
        //Vector3 movement = transform.right * moveInput.x + transform.forward * moveInput.y;

        //tapa 2 : 
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        movement = transform.TransformDirection(movement);

        if (controller.isGrounded && verticalVelocity < 0)
        {   //asetetaan pieni vetovoima maata kohti vaikka maassa, 
            //ettei isGrounded heittele esim. mäissä true/false
            verticalVelocity = -2f;
        }

        verticalVelocity += gravity * Time.deltaTime;
        movement.y = verticalVelocity;

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }

}
