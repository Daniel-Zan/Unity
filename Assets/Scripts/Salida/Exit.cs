using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Collider requiredTrigger; // El trigger que debe ser activado antes
    private bool canExit = false; // Marca si se puede salir al menú

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Verifica si el trigger requerido ha sido activado
            if (requiredTrigger != null && requiredTrigger.GetComponent<TriggerActivation>())
            {
                canExit = true; // Permitir salida al menú
                LoadMainMenu();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canExit = false; // Desactivar la posibilidad de salir al menú al salir del trigger
        }
    }

    private void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu"); // Cambia "MainMenu" por el nombre de tu escena de menú
    }
}
