using UnityEngine;

public class RotatingCapsule : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float rotationSpeed = 45f;
   
    void Update()
    {
        //pyöritetään objektia target-gameobjektin ympärillä
        transform.RotateAround(
            target.transform.position,
            Vector3.up,
            rotationSpeed * Time.deltaTime);
    }
}
