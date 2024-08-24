using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TriggerActivation : MonoBehaviour
{
    [System.Serializable]
    public class TriggerSubtitle
    {
        public Collider triggerCollider;
        public string subtitle;
    }

    public TMP_Text subtitleText; // Cambia a TMP_Text
    public List<TriggerSubtitle> triggerSubtitles = new List<TriggerSubtitle>();

    void Start()
    {
        // Inicialmente, desactivar los subtítulos
        subtitleText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscar el trigger actual en la lista de triggerSubtitles
            foreach (TriggerSubtitle triggerSubtitle in triggerSubtitles)
            {
                if (triggerSubtitle.triggerCollider == GetComponent<Collider>())
                {
                    // Mostrar el subtítulo asociado al trigger
                    subtitleText.text = triggerSubtitle.subtitle;
                    subtitleText.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ocultar los subtítulos al salir del trigger
            subtitleText.gameObject.SetActive(false);
        }
    }
}
