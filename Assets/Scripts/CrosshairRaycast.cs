using UnityEngine;

public class CrosshairRaycast : MonoBehaviour
{
    [SerializeField] RectTransform crosshair;
    [SerializeField] float rayDistance = 100f;
    [SerializeField] LayerMask hitLayers;


    void Update()
    {
        //Debug.Log(crosshair.position); // Resoluution leveys & korkeus / 2

        //Luodaan ray eli säde aktiivisesta kamerasta läpi crosshairin positiosta
        Ray ray = Camera.main.ScreenPointToRay(crosshair.position);

        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, hitLayers))
        {
            //jos osuttiin johonkin, eli raycast palautti true:
            //Debug.Log("Osutiin: " + hit.collider.name);            
        }

        //myös Screen-luokkaa voi käyttää jos haluaa keskelle ruutua
        //Ray ray = Camera.main.ScreenPointToRay(
        //    new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

    }
}
