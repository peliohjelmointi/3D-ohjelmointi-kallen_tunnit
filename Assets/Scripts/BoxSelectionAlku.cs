using UnityEngine;
using UnityEngine.InputSystem;

public class BoxSelectionAlku: MonoBehaviour
{
    [SerializeField] RectTransform boxVisual;

    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;

    private void Awake()
    {
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;

        boxVisual.sizeDelta = Vector2.zero; // hide selection box
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            startPosition = Mouse.current.position.ReadValue();
            endPosition = startPosition;

            selectionBox = new Rect();
        }

        if (Mouse.current.leftButton.isPressed)
        {
            endPosition = Mouse.current.position.ReadValue();

            DrawVisual();
            DrawSelectionRect();

            UpdateSelectionHighlight();
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            endPosition = Mouse.current.position.ReadValue();

            DrawSelectionRect();
            UpdateSelectionHighlight();

            startPosition = Vector2.zero;
            endPosition = Vector2.zero;

            DrawVisual(); // hides the rectangle because size becomes zero
        }
    }

    private void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2f;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(
            Mathf.Abs(boxStart.x - boxEnd.x),
            Mathf.Abs(boxStart.y - boxEnd.y)
        );

        boxVisual.sizeDelta = boxSize;
    }

    void DrawSelectionRect()
    {
        if (endPosition.x < startPosition.x)
        {
            selectionBox.xMin = endPosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = endPosition.x;
        }

        if (endPosition.y < startPosition.y)
        {
            selectionBox.yMin = endPosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = endPosition.y;
        }
    }

    void UpdateSelectionHighlight()
    {
        foreach (var unit in UnitManager.Instance.allUnits)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(unit.transform.position);

            bool isInsideSelectionBox = selectionBox.Contains(screenPosition);

            Renderer renderer = unit.GetComponent<Renderer>();
            Cube cube = unit.GetComponent<Cube>();

            if (isInsideSelectionBox)
            {
                renderer.material = cube.selectedMaterial;
            }
            else
            {
                renderer.material = cube.defaultMaterial;
            }
        }
    }
}