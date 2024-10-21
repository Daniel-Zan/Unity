using UnityEngine;
using TMPro; // Aseg�rate de tener el paquete TextMeshPro instalado

public class NoteInteractable : MonoBehaviour
{
    public string noteText = "Muchacho, ve al cuarto piso, estoy en uno de los laboratorios, ah� te dar� mi respuesta"; // El texto que se mostrar� al interactuar
    public TMP_Text displayText; // El componente TextMeshPro donde se mostrar� el texto
    public float activationRange = 2f; // Rango de activaci�n para mostrar el mensaje de interacci�n
    private string interactMessage = "Presiona 'E' para interactuar";
    private GameObject player; // Referencia al jugador
    private bool isInRange = false; // Marca si el jugador est� en el rango de interacci�n
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
        style.fontSize = 24; // Cambia el tama�o de la fuente aqu�
        style.normal.textColor = Color.white; // Cambia el color del texto si lo deseas

        // Verificar si el jugador puede interactuar
        if (canInteract)
        {
            // Mostrar el mensaje de interacci�n en la pantalla
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), interactMessage, style);
        }
    }

    // Este m�todo se llamar� desde el trigger cuando el jugador entre en �l
    public void EnableInteraction()
    {
        canInteract = true; // Permitir que el jugador interact�e
    }

    // Este m�todo se llamar� desde el trigger cuando el jugador salga de �l
    public void DisableInteraction()
    {
        canInteract = false; // No permitir la interacci�n
    }

    // Manejo de Trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnableInteraction(); // Habilitar interacci�n al entrar en el trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableInteraction(); // Deshabilitar interacci�n al salir del trigger
        }
    }
}
