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
        // Verificar si el jugador est� dentro del rango de activaci�n
        if (Vector3.Distance(player.transform.position, transform.position) <= activationRange)
        {
            isInRange = true; // Marcar que el jugador est� en el rango de interacci�n
        }
        else
        {
            isInRange = false; // Marcar que el jugador ha salido del rango de interacci�n
        }

        if (isInRange && Input.GetKeyDown(KeyCode.E))
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
        // Verificar si el jugador est� dentro del rango de activaci�n
        if (isInRange)
        {
            // Mostrar el mensaje de interacci�n en la pantalla
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), interactMessage);
        }
    }
}
