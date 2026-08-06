using UnityEngine;
using UnityEngine.InputSystem;

class CameraSwitch : MonoBehaviour
{
    [SerializeField]  Camera firstPersonCam;
    [SerializeField] Camera thirdPersonCam;    

    void Update()
    {
        // jos vanha input system
        // if(Input.GetKey(KeyCode.Tab)

        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            bool firstPersonCamActive = firstPersonCam.gameObject.activeSelf;

            firstPersonCam.gameObject.SetActive(!firstPersonCamActive);
            thirdPersonCam.gameObject.SetActive(firstPersonCamActive);
        }
    }
}
