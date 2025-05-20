using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaGelats : MonoBehaviour
{
    private bool t�Maduixa = false;
    private bool t�Gel = false;
    public GameObject poloMaduixaPrefab;
    public GameObject poloSpawn;

    private GameObject maduixaObjecte;
    private GameObject gelObjecte;

    // Quan un ingredient entra en el collider de la m�quina
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Un objecte ha entrat al collider: " + other.gameObject.tag);



        if (other.gameObject.tag == "Maduixa")
        {
            t�Maduixa = true;
            maduixaObjecte = other.gameObject;
            Debug.Log("Maduixa detectada");
        }
        else if (other.gameObject.tag == "Gel")
        {
            t�Gel = true;
            gelObjecte = other.gameObject;
            Debug.Log("Gel detectat");
        }
        ComprovarCombinacio();

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Un objecte ha sortit del collider: " + other.gameObject.tag);



        if (other.gameObject.tag == "Maduixa")
        {
            t�Maduixa = false;
            Debug.Log("Maduixa eliminada");
        }
        else if (other.gameObject.tag == "Gel")
        {
            t�Gel = false;
            Debug.Log("Gel eliminat");
        }

    }

    void ComprovarCombinacio()
    {
        if (t�Maduixa && t�Gel)
        {
            CrearPolo();
        }
    }

    void CrearPolo()
    {
        if (poloMaduixaPrefab != null)
        {
            Instantiate(poloMaduixaPrefab, poloSpawn.transform.position, Quaternion.identity);
           
            Debug.Log("Has creat un polo de maduixa!");

            if (maduixaObjecte != null)
            {
                Destroy(maduixaObjecte);
                Debug.Log("Maduixa destru�da");
            }

            if (gelObjecte != null)
            {
                Destroy(gelObjecte);
                Debug.Log("Gel destru�t");
            }
        }
        else
        {
            Debug.LogError("El prefab del polo de maduixa no est� assignat!");
        }

        t�Maduixa = false;
        t�Gel = false;
    }
}


