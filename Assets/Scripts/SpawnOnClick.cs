using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnOnClick : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] LayerMask desiredLayer;

    int i = 1;


    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            if(Physics.Raycast(ray, out RaycastHit hit, 100f, desiredLayer))
            {
                GameObject go = Instantiate(prefabToSpawn, hit.point, Quaternion.identity);
               
                go.transform.position = new Vector3(go.transform.position.x,0.5f,go.transform.position.z);
                //go.name = "Cube @" + go.transform.position;
                go.name = "Cube " + i.ToString();
                i++;
            }
        }
    }
}
