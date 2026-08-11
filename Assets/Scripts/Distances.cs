using UnityEngine;

public class Distances : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform target;

    private void Update()
    {
        Vector3 playerPosition = player.position;
        Vector3 targetPosition = target.position;        

        // etäisyyden laskeminen magnitudilla
        Vector3 distanceVector = playerPosition - targetPosition;
        float distance = distanceVector.magnitude;
        print("Etäisyys magnitudilla:" + distance);

        //float d = distanceVector.sqrMagnitude; 
        //if(d < 25) // objekti on alle 5m päässä (optimoitu versio)

        // etäisyys laskeminen valmiilla Distance-metodilla
        float distanceAsFloat = Vector3.Distance(playerPosition, targetPosition);
        print(distanceAsFloat);

    }


}
