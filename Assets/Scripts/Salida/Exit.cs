using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Collider requiredTrigger; // El trigger que debe ser activado antes
    public Canvas exitCanvas; // El canvas que se mostrará antes de salir
    private bool canExit = false; // Marca si se puede salir al menú

    private void Start()
    {
        // Asegúrate de que el canvas esté desactivado al inicio
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
                canExit = true; // Permitir salida al menú
                ShowExitCanvas();

    }


    private void ShowExitCanvas()
    {
        if (exitCanvas != null)
        {
            exitCanvas.gameObject.SetActive(true); // Mostrar el canvas
        }

        // Pausar el tiempo mientras se muestra el canvas
        Time.timeScale = 0f;

        // Iniciar la corrutina para esperar y luego salir
        StartCoroutine(WaitAndExit());
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
        // Como Time.timeScale es 0, usar tiempo real para esperar
        yield return new WaitForSecondsRealtime(5);

        // Restablecer la escala de tiempo antes de cargar el menú
        Time.timeScale = 1f;

        // Después de 5 segundos, cargar el menú
        LoadMainMenu();
    }

    private void LoadMainMenu()
    {
        // Hacer visible el cursor y desbloquearlo
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Cargar la escena del menú principal
        SceneManager.LoadScene("Menu"); // Cambia "Menu" por el nombre de tu escena de menú
    }

}
