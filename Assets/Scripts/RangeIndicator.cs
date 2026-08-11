using System;
using UnityEngine;
using UnityEngine.AI;

public class RangeIndicator : MonoBehaviour
{
    [SerializeField] float range = 5f;   
    [SerializeField] Material defaultMaterial;
    [SerializeField] Material highLightMaterial;
    [SerializeField] GameObject target;

    Transform rangeIndicator;

    private void Awake()
    {                   //näin voi hakea objektin childeista nopeasti
        rangeIndicator = transform.Find("RangeIndicator");
        rangeIndicator.GetComponent<Renderer>().material = defaultMaterial;
    }

    private void Update()
    {
        rangeIndicator.localScale = new Vector3(
            range, rangeIndicator.localScale.y, range);

        if(Vector3.Distance(
            transform.position,target.transform.position) < range)
        {
            target.GetComponent<Renderer>().material = highLightMaterial;
        }
        else
        {
            target.GetComponent<Renderer>().material = defaultMaterial;
        }
        //sama ternary operatorilla:       
        //target.GetComponent<Renderer>().material = Vector3.Distance(
        //    transform.position, target.transform.position) < range ?
        //    highLightMaterial : defaultMaterial;

    }
}
