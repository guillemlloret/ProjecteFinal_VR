using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertasEntrada : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Puertas;

    private void OnTriggerEnter(Collider other)
    {
        Puertas.Play("AbrirPuertas");
    }

    private void OnTriggerExit(Collider other)
    {
        Puertas.Play("CerrarPuertas");

    }
}
