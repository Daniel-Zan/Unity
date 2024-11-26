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
        public bool showOnce;  // Si el subt�tulo debe mostrarse solo una vez
        [HideInInspector] public bool hasBeenShown = false;
        public Collider previousTrigger;
    }

    public Image fondito;
    public TMP_Text subtitleText; // Cambia a TMP_Text
    public List<TriggerSubtitle> triggerSubtitles = new List<TriggerSubtitle>();

    // Referencia al componente de movimiento del jugador (asume que tienes un componente PlayerMovement)
    public GameObject player;
    private PlayerMovement playerMovement; // Suponiendo que el jugador tiene un script PlayerMovement

    private bool isMovementDisabled = false; // Bandera para saber si el movimiento ha sido deshabilitado

    void Start()
    {
        // Inicialmente, desactivar los subt�tulos
        subtitleText.gameObject.SetActive(false);

        // Obtener el componente de movimiento del jugador (ajusta esto seg�n tu implementaci�n)
        playerMovement = player.GetComponent<PlayerMovement>();
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
                        // Comprobar si el subt�tulo ya fue mostrado si "showOnce" est� activado
                        if (!triggerSubtitle.hasBeenShown)
                        {
                            // Mostrar el subt�tulo
                            subtitleText.text = triggerSubtitle.subtitle;
                            fondito.gameObject.SetActive(true);
                            subtitleText.gameObject.SetActive(true);

                            // Si el subt�tulo solo se debe mostrar una vez, marcarlo como mostrado
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
            // Ocultar los subt�tulos al salir del trigger
            subtitleText.gameObject.SetActive(false);
            fondito.gameObject.SetActive(false);
        }
    }

    // M�todo para verificar si este trigger ha sido activado antes
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
