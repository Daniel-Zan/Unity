using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerObjects : MonoBehaviour
{
    // Elementos de la UI
    public Image fondito;
    public TMP_Text subtitleText;

    // Objetivo
    public string newObjective;
    public bool modifiesObjective;
    public string subtitleMessage;

    private ObjectiveManager objectiveManager;

    // Control de activación
    public bool activateOnce;
    private bool hasActivated;

    // Audio opcional
    public AudioSource audioSource;
    public AudioClip triggerSound;

    void Start()
    {
        objectiveManager = FindObjectOfType<ObjectiveManager>();
        hasActivated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (activateOnce && hasActivated)
        {
            return;
        }

        hasActivated = true;

        // Mostrar UI
        subtitleText.text = subtitleMessage;
        subtitleText.gameObject.SetActive(true);
        fondito.gameObject.SetActive(true);

        // Reproducir sonido si está asignado
        if (audioSource != null && triggerSound != null)
        {
            audioSource.PlayOneShot(triggerSound);
        }

        // Si modifica el objetivo, actualizarlo
        if (modifiesObjective && objectiveManager != null)
        {
            objectiveManager.UpdateObjective(newObjective);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        subtitleText.gameObject.SetActive(false);
        fondito.gameObject.SetActive(false);
    }
}
