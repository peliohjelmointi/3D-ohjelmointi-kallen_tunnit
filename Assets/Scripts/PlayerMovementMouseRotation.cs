using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementMouseRotation : MonoBehaviour
{
    Transform playerTransform; //voisi olla myös [SerializeField] jos haluaa itse asettaa muualta

    float pitch = 0f;

    [SerializeField] float mouseSensitivity = 150f;
    [SerializeField] float minPitch = -45f;
    [SerializeField] float maxPitch = 45f;

    void Awake()
    {
        playerTransform = transform.parent.transform;
    }

    public void Look(InputValue value)
    {
        Vector2 lookInput = value.Get<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        //Rotate player left/right
        playerTransform.Rotate(Vector3.up * mouseX);

        //Rotate camera up/down (pitch)
        pitch -= mouseY;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }


}
