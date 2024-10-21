using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{
    public TMP_Text floorText;  // El objeto de texto TMP que mostrará el piso
    public string floorName;     // El nombre o número del piso que quieres mostrar (ej. "Piso 1", "Piso 2")

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el jugador ha entrado en el trigger
        if (other.CompareTag("Player"))
        {
            // Actualizar el texto para indicar en qué piso está el jugador
            floorText.text = "Estás en " + floorName;
        }
    }
}
