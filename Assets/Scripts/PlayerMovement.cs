using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    public Transform CameraTransform;
    private ObjInteract CurrentObjInteract;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = CameraTransform.forward * moveZ + CameraTransform.right * moveX;
        moveDirection.y = 0; // No queremos que el movimiento del jugador sea afectado por la dirección de la cámara en el eje Y

        // Calculamos la nueva velocidad, pero mantenemos la componente vertical de la velocidad actual
        Vector3 newVelocity = moveDirection.normalized * moveSpeed;
        newVelocity.y = rb.velocity.y; // Mantener la componente vertical de la velocidad

        rb.velocity = newVelocity;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }


    public void SetInteractableObject(ObjInteract intObj)
    {
        CurrentObjInteract = intObj;
    }
}