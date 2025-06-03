using UnityEngine;

public class GestorDeCubell : MonoBehaviour
{
    public GameObject prefabGel; // Assigna aquest des de l'Inspector

    void Update()
    {
        // Comprova si ja hi ha algun gel com a fill
        bool teGel = false;

        foreach (Transform fill in transform)
        {
            if (fill.CompareTag("Gel"))
            {
                teGel = true;
                break;
            }
        }

        // Si no en té, instancia un gel i l'afegeix com a fill
        if (!teGel && prefabGel != null)
        {
            GameObject nouGel = Instantiate(prefabGel, transform);
            nouGel.transform.localPosition = Vector3.zero; // Opcional: posiciona'l al centre del cubell
        }
    }
}

