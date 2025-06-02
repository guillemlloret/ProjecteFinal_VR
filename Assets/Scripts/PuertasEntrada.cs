using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasEntrada : MonoBehaviour
{

    //public bool isOpen;
    // Start is called before the first frame update
    public Animator Puertas;

    private void OnTriggerEnter(Collider other)
    {
        Puertas.SetBool("AbrirPuertas", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Puertas.SetBool("AbrirPuertas", false);

    }
}
