using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaGelats : MonoBehaviour
{
    private bool téMaduixa = false;
    private bool téGel = false;
    public GameObject poloMaduixaPrefab;
    public GameObject poloSpawn;

    private GameObject maduixaObjecte;
    private GameObject gelObjecte;

    // Quan un ingredient entra en el collider de la màquina
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Un objecte ha entrat al collider: " + other.gameObject.tag);



        if (other.gameObject.tag == "Maduixa")
        {
            téMaduixa = true;
            maduixaObjecte = other.gameObject;
            Debug.Log("Maduixa detectada");
        }
        else if (other.gameObject.tag == "Gel")
        {
            téGel = true;
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
            téMaduixa = false;
            Debug.Log("Maduixa eliminada");
        }
        else if (other.gameObject.tag == "Gel")
        {
            téGel = false;
            Debug.Log("Gel eliminat");
        }

    }

    void ComprovarCombinacio()
    {
        if (téMaduixa && téGel)
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
                Debug.Log("Maduixa destruïda");
            }

            if (gelObjecte != null)
            {
                Destroy(gelObjecte);
                Debug.Log("Gel destruït");
            }
        }
        else
        {
            Debug.LogError("El prefab del polo de maduixa no està assignat!");
        }

        téMaduixa = false;
        téGel = false;
    }
}


