using UnityEngine;

public class Tacos : MonoBehaviour
{
    public Light[] lightsToActivate; // Array para las luces que se encenderán
    private string interactMessage = "Presiona 'E' para interactuar";
    private bool canInteract = false; // Control de si el jugador está dentro del trigger
    private bool isShowingMessage = false; // Para evitar mensajes repetidos

    void Start()
    {
        // Asegurarnos de que las luces específicas estén apagadas al inicio
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (canInteract && !isShowingMessage)
        {
            // Mostrar el mensaje cuando se está en el trigger y aún no se ha interactuado
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
        // Mostrar el mensaje solo si el jugador puede interactuar y no ha interactuado aún
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
        // Activar solo las luces específicas cuando el jugador interactúe
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(true);
        }

        // Ocultar el mensaje después de interactuar
        isShowingMessage = false;
    }

    // Estos métodos son llamados por el trigger
    public void TriggerPassed()
    {
        canInteract = true;
    }

    public void DisableInteraction()
    {
        canInteract = false;
        isShowingMessage = false; // Asegurarse de que el mensaje desaparezca cuando el jugador ya no pueda interactuar
    }
}
