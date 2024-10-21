using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public TMP_Text floorText;  // El objeto de texto TMP que mostrar� el piso
    public string floorName;     // El nombre o n�mero del piso que quieres mostrar (ej. "Piso 1", "Piso 2")

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en el trigger
        if (other.CompareTag("Player"))
        {
            // Actualizar el texto para indicar en qu� piso est� el jugador
            floorText.text = "Est�s en " + floorName;
        }
    }
}
