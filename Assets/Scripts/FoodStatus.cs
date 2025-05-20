using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStatus : MonoBehaviour
{
    public bool isCompleted;
    public GameObject dispensador;
    public GameObject tarrina;

    // Start is called before the first frame update
    void Start()
    {
        isCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCompleted)
        {
            tarrina.transform.position = dispensador.transform.position;
        }
        
    }

    public void CompleteOrder()
    {
        isCompleted=true;
    }
}
