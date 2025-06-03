using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaGelats : MonoBehaviour
{
    private bool téMaduixa = false;
    private bool téLlimona = false;
    private bool téGel = false;

    public GameObject poloMaduixaPrefab;
    public GameObject poloLlimonaPrefab;
    public GameObject poloSpawn;

    private GameObject maduixaObjecte;
    private GameObject llimonaObjecte;
    private GameObject gelObjecte;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Un objecte ha entrat al collider: " + other.gameObject.tag);

        if (other.CompareTag("Maduixa"))
        {
            téMaduixa = true;
            maduixaObjecte = other.gameObject;
            Debug.Log("Maduixa detectada");
        }
        else if (other.CompareTag("Gel"))
        {
            téGel = true;
            gelObjecte = other.gameObject;
            Debug.Log("Gel detectat");
        }
        else if (other.CompareTag("Llimona"))
        {
            téLlimona = true;
            llimonaObjecte = other.gameObject;
            Debug.Log("Llimona detectada");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Un objecte ha sortit del collider: " + other.gameObject.tag);

        if (other.CompareTag("Maduixa"))
        {
            téMaduixa = false;
            maduixaObjecte = null;
            Debug.Log("Maduixa eliminada");
        }
        else if (other.CompareTag("Gel"))
        {
            téGel = false;
            gelObjecte = null;
            Debug.Log("Gel eliminat");
        }
        else if (other.CompareTag("Llimona"))
        {
            téLlimona = false;
            llimonaObjecte = null;
            Debug.Log("Llimona eliminada");
        }
    }

    // Aquesta funció es crida des de la palanca
    public void ActivarMaquina()
    {
        if (téMaduixa && téGel)
        {
            CrearPoloMaduixa();
        }
        else if (téLlimona && téGel)
        {
            CrearPoloLlimona();
        }
        else
        {
            Debug.Log("No hi ha una combinació vàlida per fer un polo.");
        }
    }

    void CrearPoloMaduixa()
    {
        if (poloMaduixaPrefab != null)
        {
            Instantiate(poloMaduixaPrefab, poloSpawn.transform.position, Quaternion.identity);
            Debug.Log("Has creat un polo de maduixa!");

            if (maduixaObjecte != null)
                Destroy(maduixaObjecte);
            if (gelObjecte != null)
                Destroy(gelObjecte);
        }

        téMaduixa = false;
        téGel = false;
    }

    void CrearPoloLlimona()
    {
        if (poloLlimonaPrefab != null)
        {
            Instantiate(poloLlimonaPrefab, poloSpawn.transform.position, Quaternion.identity);
            Debug.Log("Has creat un polo de llimona!");

            if (llimonaObjecte != null)
                Destroy(llimonaObjecte);
            if (gelObjecte != null)
                Destroy(gelObjecte);
        }

        téLlimona = false;
        téGel = false;
    }
}
