using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStatus : MonoBehaviour
{
    public bool isCompleted;

    // Start is called before the first frame update
    void Start()
    {
        isCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteOrder()
    {
        isCompleted=true;
    }
}
