using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool GameIsPaused = false;
    
    public GameObject pauseMenuUI;
    public GameObject exitConfirmationPanel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused && exitConfirmationPanel.activeSelf)
            {
                CloseExitConfirmation();
            }
            else if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Reanudar el juego
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        exitConfirmationPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
    }

    // Pausar el juego
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        exitConfirmationPanel.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
    }

    // Reiniciar la escena actual
    public void RestartGame()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo vuelva a la normalidad
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
        Cursor.lockState = CursorLockMode.Locked; // Asegurarse de bloquear el cursor después del reinicio
        Cursor.visible = false;
    }

    // Mostrar panel de confirmación
    public void ShowExitConfirmation()
    {
        exitConfirmationPanel.SetActive(true);
    }

    // Cerrar panel de confirmación
    public void CloseExitConfirmation()
    {
        exitConfirmationPanel.SetActive(false);
    }

    // Salir al menú principal
    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Asegúrate de que esta escena esté agregada en el build settings
    }

    // Salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
