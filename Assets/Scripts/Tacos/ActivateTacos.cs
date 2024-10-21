using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTacos : MonoBehaviour
{
    public Tacos tacos;  // Referencia al script Tacos

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Llamar al método TriggerPassed del script Tacos
            tacos.TriggerPassed(); // Activa la interacción
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Llamar al método para desactivar la interacción en Tacos
            tacos.DisableInteraction(); // Desactiva la interacción
        }
    }
}
