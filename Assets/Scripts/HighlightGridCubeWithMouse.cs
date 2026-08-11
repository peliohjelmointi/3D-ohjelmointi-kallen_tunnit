using UnityEngine;

public class HightlightGridCubeWithMouse : MonoBehaviour
{
    string highlightedCubeName;
    bool isMouseOver;

    void OnMouseEnter()
    {
        isMouseOver = true;
        highlightedCubeName = gameObject.name;
    }
    void OnMouseExit()
    {
        isMouseOver = false;
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 50;
        GUI.Label(new Rect(200, 100, 300, 100),isMouseOver?highlightedCubeName: "",style);
    }
}
