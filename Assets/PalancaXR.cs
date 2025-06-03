using UnityEngine;

public class PalancaXR : MonoBehaviour
{
    public MaquinaGelats maquinaGelats;
    public Transform palancaVisual; // El transform de la palanca
    public float angleActivacio = 40f;

    private bool activat = false;

    void Update()
    {
        if (palancaVisual == null || maquinaGelats == null)
            return;

        float angle = palancaVisual.localEulerAngles.x;
        if (angle > 180) angle -= 360;

        // Activació
        if (!activat && Mathf.Abs(angle) > angleActivacio)
        {
            activat = true;
            maquinaGelats.ActivarMaquina();
            Debug.Log("PALANCA: Activada a angle " + angle);
        }

        // Reset quan torna al mig
        if (activat && Mathf.Abs(angle) < 10f)
        {
            activat = false;
        }
    }
}
