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
            // Llamar al m�todo TriggerPassed del script Tacos
            tacos.TriggerPassed(); // Activa la interacci�n
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Llamar al m�todo para desactivar la interacci�n en Tacos
            tacos.DisableInteraction(); // Desactiva la interacci�n
        }
    }
}
