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
        public bool showOnce;  // Si el subtítulo debe mostrarse solo una vez
        [HideInInspector] public bool hasBeenShown = false;
        public Collider previousTrigger;
    }
    public Image fondito;
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
                    // Comprobar si el trigger anterior ha sido activado o si no hay trigger anterior
                    if (triggerSubtitle.previousTrigger == null || triggerSubtitle.previousTrigger.GetComponent<TriggerActivation>().HasBeenTriggered())
                    {
                        // Comprobar si el subtítulo ya fue mostrado si "showOnce" está activado
                        if (!triggerSubtitle.hasBeenShown)
                        {
                            // Mostrar el subtítulo
                            subtitleText.text = triggerSubtitle.subtitle;
                            fondito.gameObject.SetActive(true);
                            subtitleText.gameObject.SetActive(true);

                            // Si el subtítulo solo se debe mostrar una vez, marcarlo como mostrado
                            if (triggerSubtitle.showOnce)
                            {
                                triggerSubtitle.hasBeenShown = true;
                            }
                        }
                    }
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
            fondito.gameObject.SetActive(false);
        }
    }

    // Método para verificar si este trigger ha sido activado antes
    public bool HasBeenTriggered()
    {
        foreach (TriggerSubtitle triggerSubtitle in triggerSubtitles)
        {
            if (triggerSubtitle.triggerCollider == GetComponent<Collider>())
            {
                return triggerSubtitle.hasBeenShown;
            }
        }
        return false;
    }

}
