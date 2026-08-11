using UnityEngine;
using UnityEngine.InputSystem;

public class MousePositionLogger : MonoBehaviour
{
    void Update()
    {
        // luetaan hiiren positio Vector3-arvoon
        Vector3 screenPos = Mouse.current.position.ReadValue();// vanhassa Input.mousePosition

        // konvertoidaan 2D screen position 3D world position (koordinaatistoksi)
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(
            new Vector3(screenPos.x, screenPos.y, Camera.main.nearClipPlane));

        // logataan positiot
        Debug.Log($"Screen Position: {screenPos}");
        Debug.Log($"World Position: {worldPos}");

    }
}
