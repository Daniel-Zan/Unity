using System.Collections;
using UnityEngine;
using TMPro;

public class Instrucciones : MonoBehaviour
{
    public TextMeshProUGUI textoUI;       // Texto donde se muestra el mensaje
    public GameObject panelMensaje;       // Panel de fondo (opcional)
    [TextArea]
    public string mensaje = "Presiona E para interactuar.";  // Mensaje a mostrar

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (textoUI != null)
            textoUI.text = mensaje;

        if (panelMensaje != null)
            panelMensaje.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (panelMensaje != null)
            panelMensaje.SetActive(false);
    }
}
