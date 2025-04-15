using UnityEngine;
using System;

public class Tacos : MonoBehaviour
{
    public Light[] lightsToActivate; // Luces que se encender�n
    public AudioSource audioSource;  // Componente de audio para el sonido de interacci�n

    private string interactMessage = "Presiona 'E' para encender la luz";
    private bool canInteract = false; // Si el jugador est� dentro del trigger
    private bool hasInteracted = false; // Para saber si ya se hizo la interacci�n

    public Action onInteract;

    void Start()
    {
        // Asegurar que las luces est�n apagadas al inicio
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (canInteract && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }

    }

    void OnGUI()
    {
        if (canInteract && !hasInteracted)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                fontSize = 36,
                wordWrap = true, // Muy importante para que no se corte
                alignment = TextAnchor.MiddleCenter,
                normal = { textColor = Color.white }
            };

            GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height - 200, 500, 200), interactMessage, style);
        }
    }

    private void Interact()
    {
        // Encender las luces
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(true);
        }

        // Reproducir sonido
        if (audioSource != null)
        {
            audioSource.Play();
        }

        hasInteracted = true;  // Ya se interactu�, ocultar mensaje
        canInteract = false;

        // Llamar a quien est� escuchando el evento (como el TutorialManager)
        onInteract?.Invoke();
    }

    public void TriggerPassed()
    {
        if (!hasInteracted)
        {
            canInteract = true;
        }
    }

    public void DisableInteraction()
    {
        canInteract = false;
    }

    public void EnableInteraction()
    {
        canInteract = true;
        hasInteracted = false; // Por si lo reus�s en otra escena
    }
}
