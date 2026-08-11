using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Morko : MonoBehaviour
{
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material selectedMaterial;

    Renderer rend;
    NavMeshAgent agent;

    public bool isSelected = false; //alussa ei voi liikuttaa mörköä

    private void Awake()
    {
        rend = GetComponent<Renderer>(); //renderer varattu sana siellä täällä
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();// vanhassa Input.mousePosition               
        Ray ray = Camera.main.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //Vasen klikkaus-check:
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                //löytyykö osutulta gameobjektilta Morko-skripti?
                Morko morko = hit.collider.GetComponent<Morko>();

                if (morko != null) //löytyi             
                    SelectOrDeselect(isSelected); // muutetaan isActive 
                                                //ja materiaali
                                                //päinvastaiseksi
                
                else //ei klikattu vasemmalla mörköä
                    SelectOrDeselect(true); //muutetaan falseksi                
            }

            //Oikea klikkaus:
            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                if (isSelected) //vain jos hahmo "valittuna"
                {
                    agent.SetDestination(hit.point);
                }
            }

        }
    }


    public void SelectOrDeselect(bool selected)
    {
        isSelected = !selected;
        rend.material = isSelected ? selectedMaterial : defaultMaterial;
    }

}
