using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectarClienteYGenerarReceta : MonoBehaviour
{
    public XRNode manoDerecha = XRNode.RightHand; // El controlador derecho
    public float distanciaMaxRaycast = 5f;
    public LayerMask layerClientes; 

    private InputDevice dispositivoDerecho;
    private bool gatilloPresionado = false;

    void Start()
    {

        dispositivoDerecho = InputDevices.GetDeviceAtXRNode(manoDerecha);

        if (!InputDevices.GetDeviceAtXRNode(manoDerecha).isValid)
        {
            Debug.LogWarning("No se encontró el dispositivo del controlador derecho.");
        }
        

    }
    

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * distanciaMaxRaycast, Color.red);

        // Detectar si se pulsa el gatillo del controlador derecho
        if (dispositivoDerecho.TryGetFeatureValue(CommonUsages.gripButton, out bool presionado))
        {
            if (presionado && !gatilloPresionado)
            {
                gatilloPresionado = true;
                RaycastYDetectarCliente();
            }
            else if (!presionado)
            {
                gatilloPresionado = false;
            }
        }

        RaycastYDetectarCliente();

    }

    void RaycastYDetectarCliente()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        // Esto dibuja una línea roja visible en la escena por 2 segundos
        Debug.DrawRay(ray.origin, ray.direction * distanciaMaxRaycast, Color.red, 2f);

        if (Physics.Raycast(ray, out RaycastHit hit, distanciaMaxRaycast, layerClientes))
        {
            Debug.Log($"¡Cliente detectado: {hit.collider.name}!");

            // Buscar el generador de recetas en la escena
            RecetaAleatoria generador = FindObjectOfType<RecetaAleatoria>();

            if (generador != null)
            {
                // Elegir aleatoriamente entre yogur o polo
                if (Random.value < 0.5f)
                {
                    var receta = generador.CrearYogurAleatorio();
                    Debug.Log($"Receta generada: {receta}");
                }
                else
                {
                    var receta = generador.CrearPoloAleatorio();
                    Debug.Log($"Receta generada: {receta}");
                }
            }
            else
            {
                Debug.Log("No se encontró un generador de recetas en la escena.");
            }
        }
    }
}
