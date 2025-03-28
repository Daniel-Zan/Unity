using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject currentArrowGroup; // Flechas que deben desactivarse al pasar
    public GameObject nextArrowGroup; // Flechas que deben activarse al pasar

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegurar que solo el jugador active el trigger
        {
            // Desactiva las flechas actuales
            if (currentArrowGroup != null)
            {
                currentArrowGroup.SetActive(false);
            }

            // Activa las siguientes flechas solo si hay un siguiente grupo
            if (nextArrowGroup != null)
            {
                nextArrowGroup.SetActive(true);
            }
        }
    }
}

