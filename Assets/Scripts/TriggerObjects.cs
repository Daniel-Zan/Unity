using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TriggerObjects : MonoBehaviour
{
    // Elementos de la UI
    public Image fondito;
    public TMP_Text subtitleText;

    // Objetivo
    public string newObjective;
    public bool modifiesObjective; // Booleano para decidir si el trigger modifica el objetivo
    public string subtitleMessage; // Mensaje del subtítulo

    private ObjectiveManager objectiveManager;

    // Control de activación
    public bool activateOnce; // Si el trigger debe ejecutarse solo una vez
    private bool hasActivated; // Controla si el trigger ya se ha activado

    // Start se ejecuta al iniciar
    void Start()
    {
        // Obtener referencia al administrador de objetivos, si es necesario
        objectiveManager = FindObjectOfType<ObjectiveManager>();
        hasActivated = false; // Inicializar el estado de activación
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el trigger debe ejecutarse solo una vez y si ya ha sido activado
        if (activateOnce && hasActivated)
        {
            return;
        }

        // Actualizar estado de activación
        hasActivated = true;

        // Mostrar subtítulo y fondo
        subtitleText.text = subtitleMessage;
        subtitleText.gameObject.SetActive(true);
        fondito.gameObject.SetActive(true);

        // Si modifica el objetivo, actualizar el objetivo
        if (modifiesObjective && objectiveManager != null)
        {
            objectiveManager.UpdateObjective(newObjective);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Siempre ocultar la UI al salir del trigger, sin importar `activateOnce`
        subtitleText.gameObject.SetActive(false);
        fondito.gameObject.SetActive(false);
    }
}
