using UnityEngine;

public class Tacos : MonoBehaviour
{
    public Light[] lightsToActivate;  // Array para las luces que se encenderán
    public float activationRange = 2f;
    private string interactMessage = "Presiona 'E' para interactuar";
    private GameObject player;
    private bool canInteract = false;  // Solo será true cuando se pase por el trigger

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Buscar el jugador por etiqueta
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Solo permitir la interacción si canInteract es verdadero
        if (canInteract && Vector3.Distance(player.transform.position, transform.position) <= activationRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        // Activar las luces
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(true);
        }
    }

    void OnGUI()
    {
        // Crear un estilo para el texto
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24; // Cambia el tamaño de la fuente aquí
        style.normal.textColor = Color.white; // Cambia el color del texto si lo deseas

        // Verificar si el jugador está dentro del rango de activación y puede interactuar
        if (canInteract)
        {
            // Mostrar el mensaje de interacción en la pantalla
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), interactMessage, style);
        }
    }

    // Este método se llamará desde otro script cuando el jugador pase por un trigger específico
    public void TriggerPassed()
    {
        canInteract = true;  // Permitir que el jugador interactúe
    }

    // Método para desactivar la interacción
    public void DisableInteraction()
    {
        canInteract = false;  // Desactivar la interacción
    }
}
