using System.Collections;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public Canvas exitCanvas; // El canvas que se mostrará temporalmente
    public Canvas objetivosCanvas; // El canvas con los objetivos que se debe ocultar
    private bool hasTriggered = false; // Para asegurarse de que solo se active una vez

    private void Start()
    {
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            StartCoroutine(PauseGame());
        }
    }

    private IEnumerator PauseGame()
    {
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(true);
        }

        if (objetivosCanvas != null)
        {
            objetivosCanvas.gameObject.SetActive(false); // Ocultar objetivos
        }

        Time.timeScale = 0; // Pausar el juego

        yield return new WaitForSecondsRealtime(6); // Esperar 6 segundos en tiempo real

        Time.timeScale = 1; // Reanudar el juego

        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false);
        }

        gameObject.SetActive(false); // Desactivar el trigger
    }
}