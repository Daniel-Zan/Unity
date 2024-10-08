using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInteract : MonoBehaviour
{
    public GameObject interactMessage; // Mensaje "E" para interactuar
    public float interactionDistance = 3f; // Distancia m�nima para poder interactuar

    private bool playerInRange = false; // Si el jugador est� en rango para interactuar
    private Transform player; // Referencia al jugador

    void Start()
    {
        // Asegurarse de que el mensaje est� oculto al inicio
        interactMessage.SetActive(false);
        // Encontrar el objeto jugador, puedes cambiar el "Player" por el tag/nombre de tu jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Comprobar la distancia entre el jugador y el objeto interactuable
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactionDistance)
        {
            // Mostrar el mensaje de interacci�n si el jugador est� cerca
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
            // Ocultar el mensaje si el jugador est� lejos
            interactMessage.SetActive(false);
            playerInRange = false;
        }
    }

    // Funci�n de interacci�n
    void Interact()
    {
        // Aqu� va lo que debe pasar cuando se interact�a
        Debug.Log("Has interactuado con la esfera!");
        // Puedes poner alguna acci�n espec�fica aqu�, como abrir una puerta o recoger un objeto
    }
}
