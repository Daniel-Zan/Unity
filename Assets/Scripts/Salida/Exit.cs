using System.Collections;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public Collider requiredTrigger; // El trigger que debe ser activado antes
    public Canvas exitCanvas; // El canvas que se mostrará temporalmente
    private bool canShowMessage = false; // Marca si se puede mostrar el mensaje

    private void Start()
    {
        // Asegurarse de que el canvas esté desactivado al inicio
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!canShowMessage)
        {
            canShowMessage = true;
            ShowExitCanvas();
        }
    }

    private void ShowExitCanvas()
    {
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(true); // Mostrar el canvas
        }

        // Iniciar la corrutina para esperar y luego ocultar el mensaje
        StartCoroutine(WaitAndHide());
    }

    private IEnumerator WaitAndHide()
    {
        yield return new WaitForSeconds(10); // Esperar 10 segundos

        // Ocultar el canvas
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false);
        }

        canShowMessage = false; // Permitir que el mensaje se muestre nuevamente si es necesario
    }
}
