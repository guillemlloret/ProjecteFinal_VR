using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingMachine : MonoBehaviour
{
    [SerializeField] private BoxCollider PlaceItemsAreaBoxCollider;
    private void Awake()
    {
        NextRecipe();
    }

    public void NextRecipe()
    {

    }
    public void Craft()
    {
        Debug.Log("Craft");
        Collider[] colliderArray = Physics.OverlapBox(transform.position + PlaceItemsAreaBoxCollider.center, PlaceItemsAreaBoxCollider.size,
            PlaceItemsAreaBoxCollider.transform.rotation);

        foreach (Collider collider in colliderArray)
        {
            Debug.Log("Collider");
        }
    }
}
