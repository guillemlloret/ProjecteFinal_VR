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
        if (isOnMachine && !isCompleted)
        {
            tarrina.transform.position = dispensador.transform.position;
            if (tarrina.transform.position == dispensador.transform.position)
            {
                _tarrinaAnimator.SetBool("Fall2", true);
            }
        }

        //if (isCompleted)
        //{
            
        //    tarrina.transform.position = new Vector3(tarrina.transform.position.x, tarrina.transform.position.y, tarrina.transform.position.z);

        //}

    }

    public void CompleteOrder()
    {
        isCompleted=true;
    }

}
