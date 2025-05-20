using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodStatus : MonoBehaviour
{
    public bool isOnMachine;
    public bool isCompleted;
    public GameObject dispensador;
    public GameObject tarrina;
    public Animator _tarrinaAnimator;

    // Start is called before the first frame update
    void Start()
    {
        isCompleted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnMachine)
        {
            tarrina.transform.position = dispensador.transform.position;
            if (tarrina.transform.position == dispensador.transform.position)
            {
                _tarrinaAnimator.SetBool("Fall2", true);
            }
        }

        if (isCompleted)
        {
            tarrina.transform.position = null;
           
        }

    }

    public void CompleteOrder()
    {
        isCompleted=true;
    }

}
