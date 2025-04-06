using UnityEngine;

public class Arrows : MonoBehaviour
{
    public GameObject currentArrowGroup; // Flechas que deben desactivarse al pasar
    public GameObject nextArrowGroup; // Flechas que deben activarse al pasar

    private bool hasActivated = false; // Asegura que solo suceda una vez

    private void OnTriggerEnter(Collider other)
    {
        if (!hasActivated && other.CompareTag("Player")) // Verifica si ya ocurrió
        {
            hasActivated = true;

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

