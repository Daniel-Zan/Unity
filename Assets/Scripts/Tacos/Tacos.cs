using UnityEngine;

public class Tacos : MonoBehaviour
{
    public Light[] lightsToActivate; // Luces que se encenderán
    public AudioSource audioSource;  // Componente de audio para el sonido de interacción

    private string interactMessage = "Presiona 'E' para interactuar";
    private bool canInteract = false; // Control de si el jugador está dentro del trigger
    private bool isShowingMessage = false; // Para evitar mensajes repetidos

    void Start()
    {
        // Asegurarnos de que las luces estén apagadas al inicio
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (canInteract && !isShowingMessage)
        {
            isShowingMessage = true;
        }

        // Detectar si el jugador presiona la tecla 'E'
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void OnGUI()
    {
        if (isShowingMessage)
        {
            GUIStyle style = new GUIStyle(GUI.skin.label)
            {
                fontSize = 36,
                normal = { textColor = Color.white }
            };

            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 100, 200, 50), interactMessage, style);
        }
    }

    private void Interact()
    {
        // Activar luces
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(true);
        }

        // Reproducir sonido si está asignado
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // Ocultar el mensaje después de interactuar
        isShowingMessage = false;
    }

    public void TriggerPassed()
    {
        canInteract = true;
    }

    public void DisableInteraction()
    {
        canInteract = false;
        isShowingMessage = false;
    }
}
