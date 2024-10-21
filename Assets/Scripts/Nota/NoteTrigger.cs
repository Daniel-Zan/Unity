using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTrigger : MonoBehaviour
{
    public NoteInteractable noteInteractable; // Referencia al script NoteInteractable

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            noteInteractable.EnableInteraction(); // Activar la interacci�n
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            noteInteractable.DisableInteraction(); // Desactivar la interacci�n
        }
    }
}
