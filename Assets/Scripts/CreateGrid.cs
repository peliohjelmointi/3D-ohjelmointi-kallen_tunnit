using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    [SerializeField] GameObject gridCubePrefab;

    float offset = 1.1f;
    void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                GameObject cube = Instantiate(gridCubePrefab, new Vector3(x*offset, y*offset, 0), Quaternion.identity);
                cube.name = $"Cube {x},{y}";
                cube.transform.parent = transform;
            }
        }
    }
}
