using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        // Activar/desactivar el menú de pausa con Escape
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (GameIsPaused)
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
        Time.timeScale = 1f; // Vuelve el tiempo a la normalidad
        Cursor.lockState = CursorLockMode.Locked; // Oculta y bloquea el cursor en el centro de la pantalla
        Cursor.visible = false; // Hace invisible el cursor
        GameIsPaused = false;
    }

    // Pausar el juego
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo en el juego
        Cursor.lockState = CursorLockMode.None; // Libera el cursor
        Cursor.visible = true; // Hace visible el cursor
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

    // Salir del juego
    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Funciona en la build, no en el editor
    }
}
