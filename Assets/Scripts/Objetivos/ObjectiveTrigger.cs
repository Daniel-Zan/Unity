using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public string newObjective;  // El nuevo objetivo que queremos agregar
    private ObjectiveManager objectiveManager;

    void Start()
    {
        // Buscar el ObjectiveManager en la escena
        objectiveManager = FindObjectOfType<ObjectiveManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el trigger
        if (other.CompareTag("Player"))
        {
            // Actualizar la barra de objetivos
            objectiveManager.UpdateObjective(newObjective);
            // Desactivar el trigger para que no se repita
            gameObject.SetActive(false);
        }
    }
}
