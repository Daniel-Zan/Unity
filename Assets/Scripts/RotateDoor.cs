using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoor : MonoBehaviour
{
    public Transform objectToRotate; // Objeto que rotará
    public Vector3 rotationAmount = new Vector3(0, 85, 0); // Rotación (por defecto 85° en Y)
    private bool hasRotated = false; // Asegura que solo pase una vez

    private void OnTriggerEnter(Collider other)
    {
        if (!hasRotated && other.CompareTag("Player"))
        {
            hasRotated = true;
            objectToRotate.Rotate(rotationAmount);
        }
    }
}
