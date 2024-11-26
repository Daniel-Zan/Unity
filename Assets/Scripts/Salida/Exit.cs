using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Collider requiredTrigger; // El trigger que debe ser activado antes
    public Canvas exitCanvas; // El canvas que se mostrar� antes de salir
    private bool canExit = false; // Marca si se puede salir al men�

    private void Start()
    {
        // Aseg�rate de que el canvas est� desactivado al inicio
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifica si el trigger requerido ha sido activado
            if (requiredTrigger != null && requiredTrigger.GetComponent<TriggerActivation>())
            {
                canExit = true; // Permitir salida al men�
                ShowExitCanvas();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canExit = false; // Desactivar la posibilidad de salir al men� al salir del trigger
            HideExitCanvas(); // Ocultar el canvas si el jugador sale del trigger
        }
    }

    private void ShowExitCanvas()
    {
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(true); // Mostrar el canvas
        }
        StartCoroutine(WaitAndExit()); // Esperar 5 segundos antes de salir
    }

    private void HideExitCanvas()
    {
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false); // Ocultar el canvas si es necesario
        }
    }

    private IEnumerator WaitAndExit()
    {
        // Esperar 5 segundos
        yield return new WaitForSeconds(5);

        // Despu�s de 5 segundos, cargar el men�
        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu"); // Cambia "Menu" por el nombre de tu escena de men�
    }
}
