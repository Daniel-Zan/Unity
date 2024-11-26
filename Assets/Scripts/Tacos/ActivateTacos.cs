using UnityEngine;

public class ActivateTacos : MonoBehaviour
{
    public Tacos tacos; // Referencia al script Tacos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tacos.TriggerPassed(); // Habilitar interacción
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tacos.DisableInteraction(); // Deshabilitar interacción
        }
    }
}
