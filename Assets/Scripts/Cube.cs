using UnityEngine;

public class Cube : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;

    void Start()
    {
        UnitManager.Instance.allUnits.Add(gameObject);
    }

}
