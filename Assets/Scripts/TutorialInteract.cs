using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar niveles

public class TutorialInteract : MonoBehaviour
{
    public GameObject interactMessage; // Mensaje "E" para interactuar
    public float interactionDistance = 3f; // Distancia mínima para poder interactuar
    private bool playerInRange = false; // Si el jugador está en rango para interactuar
    private Transform player; // Referencia al jugador
    private bool hasInteracted = false; // Si ya se ha interactuado

    public string nextLevelName; // Nombre del siguiente nivel

    void Start()
    {
        // Asegurarse de que el mensaje esté oculto al inicio
        interactMessage.SetActive(false);
        // Encontrar el objeto jugador, puedes cambiar el "Player" por el tag/nombre de tu jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Comprobar la distancia entre el jugador y el objeto interactuable
        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= interactionDistance && !hasInteracted)
        {
            // Mostrar el mensaje de interacción si el jugador está cerca y aún no ha interactuado
            interactMessage.SetActive(true);
            playerInRange = true;

            // Detectar si el jugador presiona "E" para interactuar
            if (Input.GetKeyDown(KeyCode.E) && playerInRange)
            {
                Interact();
            }
        }
        else
        {
            // Ocultar el mensaje si el jugador está lejos o ya interactuó
            interactMessage.SetActive(false);
            playerInRange = false;
        }
    }

    // Función de interacción
    void Interact()
    {
        Debug.Log("Has interactuado con la esfera!");
        hasInteracted = true; // Marcar como interactuado
        interactMessage.SetActive(false); // Ocultar el mensaje de interacción

        // Pausar el juego y llamar al Coroutine para esperar 5 segundos
        StartCoroutine(WaitAndLoadNextLevel());
    }

    IEnumerator WaitAndLoadNextLevel()
    {
        // Pausar el juego
        Time.timeScale = 0;
        Debug.Log("Juego pausado por 5 segundos...");

        // Esperar 5 segundos en tiempo real
        float pauseTime = 3f;
        float elapsed = 0f;
        while (elapsed < pauseTime)
        {
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        // Restaurar el tiempo y cargar el siguiente nivel
        Time.timeScale = 1;
        Debug.Log("Cargando el siguiente nivel...");
        SceneManager.LoadScene(nextLevelName);
    }
}
