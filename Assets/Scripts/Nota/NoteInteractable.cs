using UnityEngine;
using TMPro; // Asegúrate de tener el paquete TextMeshPro instalado

public class NoteInteractable : MonoBehaviour
{
    public string noteText = "Muchacho, ve al cuarto piso, estoy en uno de los laboratorios, ahí te daré mi respuesta"; // El texto que se mostrará al interactuar
    public TMP_Text displayText; // El componente TextMeshPro donde se mostrará el texto
    public float activationRange = 2f; // Rango de activación para mostrar el mensaje de interacción
    private string interactMessage = "Presiona 'E' para interactuar";
    private GameObject player; // Referencia al jugador
    private bool isInRange = false; // Marca si el jugador está en el rango de interacción
    private bool canInteract = false; // Marca si se puede interactuar (activado por el trigger)

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Buscar el jugador por etiqueta
        if (displayText != null)
        {
            displayText.gameObject.SetActive(false); // Ocultar el texto inicialmente
        }
    }

    void Update()
    {
        // Verificar si el jugador puede interactuar y si presiona la tecla 'E'
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        if (displayText != null)
        {
            displayText.text = noteText; // Mostrar el texto de la nota
            displayText.gameObject.SetActive(true); // Activar el componente TextMeshPro
        }
    }

    void OnGUI()
    {
        // Crear un estilo para el texto
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24; // Cambia el tamaño de la fuente aquí
        style.normal.textColor = Color.white; // Cambia el color del texto si lo deseas

        // Verificar si el jugador puede interactuar
        if (canInteract)
        {
            // Mostrar el mensaje de interacción en la pantalla
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), interactMessage, style);
        }
    }

    // Este método se llamará desde el trigger cuando el jugador entre en él
    public void EnableInteraction()
    {
        canInteract = true; // Permitir que el jugador interactúe
    }

    // Este método se llamará desde el trigger cuando el jugador salga de él
    public void DisableInteraction()
    {
        canInteract = false; // No permitir la interacción
    }

    // Manejo de Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableInteraction(); // Habilitar interacción al entrar en el trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableInteraction(); // Deshabilitar interacción al salir del trigger
        }
    }
}
