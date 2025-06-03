using UnityEngine;
using System.Collections.Generic;

public class DetectorDeGels : MonoBehaviour
{
    public GameObject prefabGel;
    public Transform posicioSpawn; // On vols que aparegui el nou gel

    private List<GameObject> gelsDins = new List<GameObject>();

    private void OnTriggerEnter(Collider altre)
    {
        if (altre.CompareTag("Gel"))
        {
            if (!gelsDins.Contains(altre.gameObject))
            {
                gelsDins.Add(altre.gameObject);
                Debug.Log("Gel ha entrat al cubell.");
            }
        }
    }

    private void OnTriggerExit(Collider altre)
    {
        if (altre.CompareTag("Gel"))
        {
            gelsDins.Remove(altre.gameObject);
            Debug.Log("Gel ha sortit del cubell.");
        }
    }

    void Update()
    {
        // Elimina referències nulles
        gelsDins.RemoveAll(gel => gel == null);

        // Si el cubell està buit, crea un nou gel
        if (gelsDins.Count == 0 && prefabGel != null)
        {
            Debug.Log("Cubell buit. Creant nou gel.");
            GameObject nouGel = Instantiate(prefabGel, posicioSpawn.position, Quaternion.identity);
            nouGel.tag = "Gel";
        }
    }
}
