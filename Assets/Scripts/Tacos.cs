using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tacos : MonoBehaviour
{
    public Light[] lightsToActivate;  // Array para las luces que se encenderán
    public float activationRange = 2f;
    private string interactMessage = "Presiona 'E' para interactuar";
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Buscar el jugador por etiqueta
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= activationRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }
        
    }


    private void Interact()
    {
        // Activar las luces
        foreach (Light light in lightsToActivate)
        {
            light.gameObject.SetActive(true);
        }
    }

    void OnGUI()
    {
        // Verificar si el jugador está dentro del rango de activación
        if (Vector3.Distance(player.transform.position, transform.position) <= activationRange)
        {
            // Mostrar el mensaje de interacción en la pantalla
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), interactMessage);
        }
    }

}
