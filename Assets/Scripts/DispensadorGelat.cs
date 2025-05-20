using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispensadorGelat : MonoBehaviour
{
   
    //public  static FoodStatus  _instance;
    // Start is called before the first frame update
    public void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void OnTriggerEnter(Collider gelat)
    {

        FoodStatus _statusFood = gelat.GetComponent<FoodStatus>();
        _statusFood.isOnMachine = true;
        
    }
}
