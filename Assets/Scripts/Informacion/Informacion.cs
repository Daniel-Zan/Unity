using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Informacion : MonoBehaviour
{
    public AudioSource audioToPlay;              // Audio que se reproducirá
    public GameObject player;                    // Referencia al jugador
    public MonoBehaviour playerMovementScript;   // Script de movimiento del jugador
    public GameObject objectToDisable;           // Objeto que se desactivará tras reproducir el audio
    public GameObject mensajePantalla;           // Panel o texto de mensaje (Canvas con TextMeshPro)

    private bool isPlaying = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isPlaying || !other.CompareTag("Player"))
            return;

        isPlaying = true;
        playerMovementScript.enabled = false; // Desactivar movimiento
        audioToPlay.Play();

        if (mensajePantalla != null)
            mensajePantalla.SetActive(true); // Mostrar el mensaje

        if (objectToDisable != null)
            objectToDisable.SetActive(false);

        // Llamar método cuando termine el audio
        Invoke(nameof(EnableMovement), audioToPlay.clip.length);
    }

    private void EnableMovement()
    {
        playerMovementScript.enabled = true; // Reactivar movimiento

        if (mensajePantalla != null)
        {
            mensajePantalla.SetActive(false); // Ocultar el mensaje
            if (objectToDisable != null)
                objectToDisable.SetActive(true);
        }
            

        isPlaying = false; // Permitir futuras activaciones
    }
}
