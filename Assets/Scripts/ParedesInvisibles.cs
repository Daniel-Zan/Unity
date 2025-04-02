using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedesInvisibles : MonoBehaviour
{
    [Header("Pared a desactivar")]
    public GameObject wallToDisable; // La pared que se desactivará al entrar en el trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Solo se activa si el jugador toca el trigger
        {
            if (wallToDisable != null)
            {
                wallToDisable.SetActive(false); // Desactivar la pared
            }
            gameObject.SetActive(false); // Desactivar el trigger para que no se active de nuevo
        }
    }
}
