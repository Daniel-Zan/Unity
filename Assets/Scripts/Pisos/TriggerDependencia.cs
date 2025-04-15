using UnityEngine;

public class TriggerDependencia : MonoBehaviour
{
    public GameObject triggerDependencia; // El trigger que debe ser activado primero
    private bool trigger1Activado = false;  // Bandera para saber si el Trigger 1 fue activado

    private void Start()
    {
        // Asegúrate de que el trigger de dependencia esté desactivado inicialmente
        if (triggerDependencia != null)
        {
            triggerDependencia.SetActive(false);  // El trigger de dependencia está desactivado al principio
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si el trigger de dependencia está activado o no es necesario
            if (!trigger1Activado)
            {
                // Cuando el jugador pase por el Trigger 1, activamos el Trigger 2
                if (triggerDependencia != null)
                {
                    triggerDependencia.SetActive(true);  // Activa el Trigger 2
                    trigger1Activado = true;  // Marca que el Trigger 1 ya ha sido activado
                    Debug.Log("Trigger 1 activado. Ahora puedes activar el Trigger 2.");
                }
            }
            else
            {
                // Si ya se activó el Trigger 1, ahora puedes activar el Trigger 2
                Debug.Log(gameObject.name + " activado.");
                // Agrega aquí el código para lo que debe hacer el Trigger 2 cuando se activa
            }
        }
    }

    // Método para activar este trigger externamente si lo deseas
    public void ActivarTrigger()
    {
        if (trigger1Activado)
        {
            // Aquí puedes activar efectos visuales, sonidos, etc.
            gameObject.SetActive(true); // Activa este trigger
        }
    }
}
