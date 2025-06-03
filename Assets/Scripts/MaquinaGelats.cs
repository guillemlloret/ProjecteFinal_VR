using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaGelats : MonoBehaviour
{
    private bool t�Maduixa = false;
    private bool t�Llimona = false;
    private bool t�Gel = false;

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
            t�Maduixa = true;
            maduixaObjecte = other.gameObject;
            Debug.Log("Maduixa detectada");
        }
        else if (other.CompareTag("Gel"))
        {
            t�Gel = true;
            gelObjecte = other.gameObject;
            Debug.Log("Gel detectat");
        }
        else if (other.CompareTag("Llimona"))
        {
            t�Llimona = true;
            llimonaObjecte = other.gameObject;
            Debug.Log("Llimona detectada");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Un objecte ha sortit del collider: " + other.gameObject.tag);

        if (other.CompareTag("Maduixa"))
        {
            t�Maduixa = false;
            maduixaObjecte = null;
            Debug.Log("Maduixa eliminada");
        }
        else if (other.CompareTag("Gel"))
        {
            t�Gel = false;
            gelObjecte = null;
            Debug.Log("Gel eliminat");
        }
        else if (other.CompareTag("Llimona"))
        {
            t�Llimona = false;
            llimonaObjecte = null;
            Debug.Log("Llimona eliminada");
        }
    }

    // Aquesta funci� es crida des de la palanca
    public void ActivarMaquina()
    {
        if (t�Maduixa && t�Gel)
        {
            CrearPoloMaduixa();
        }
        else if (t�Llimona && t�Gel)
        {
            CrearPoloLlimona();
        }
        else
        {
            Debug.Log("No hi ha una combinaci� v�lida per fer un polo.");
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

        t�Maduixa = false;
        t�Gel = false;
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

        t�Llimona = false;
        t�Gel = false;
    }
}
