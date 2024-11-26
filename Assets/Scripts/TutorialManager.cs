using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialSteps; // Arreglo de paneles de tutorial (instrucciones)
    public int currentStep = 0; // Paso actual del tutorial
    public string nextLevelName; // Nombre del nivel real para cargar al terminar
    public MonoBehaviour playerMovementScript; // Referencia al script que controla el movimiento del jugador

    void Start()
    {
        // Asegurarse de que solo el primer paso esté activo al inicio
        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            tutorialSteps[i].SetActive(i == currentStep);
        }
    }

    void Update()
    {
        // Si es el primer paso, esperar a que el jugador mueva el ratón
        if (currentStep == 0)
        {
            if (DetectMouseMovement())
            {
                NextStep();
            }
        }
        // Si es el segundo paso, esperar a que el jugador use las teclas de movimiento
        else if (currentStep == 1)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                NextStep();
            }
        }
        else if (currentStep == 2)
        {
            if (Input.GetKeyDown(KeyCode.E)) // Cambia 'E' por la tecla de interacción que estés usando
            {
                NextStep();
            }
        }
        else if (currentStep == 3)
        {
            // Desactivar el movimiento del jugador y esperar
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = false; // Desactiva el movimiento
            }
            StartCoroutine(WaitAndProceed(5f)); // Esperar 5 segundos antes de avanzar al siguiente paso
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SkipTutorial();
        }
    }

    IEnumerator WaitAndProceed(float waitTime)
    {
        // Mostrar el paso actual
        tutorialSteps[currentStep].SetActive(true);

        // Esperar los segundos que se pasen como parámetro
        yield return new WaitForSeconds(waitTime);

        // Proceder al siguiente paso
        NextStep();
    }

    public void NextStep()
    {
        // Desactivar el paso actual
        tutorialSteps[currentStep].SetActive(false);

        // Avanzar al siguiente paso
        currentStep++;

        // Si ya no hay más pasos, cargar el siguiente nivel
        if (currentStep >= tutorialSteps.Length)
        {
            LoadNextLevel();
        }
        else
        {
            // Reactivar el movimiento del jugador si es necesario
            if (currentStep != 3 && playerMovementScript != null)
            {
                playerMovementScript.enabled = true;
            }

            // Activar el siguiente paso
            tutorialSteps[currentStep].SetActive(true);
        }
    }

    public void SkipTutorial()
    {
        LoadNextLevel(); // Cargar el siguiente nivel si se salta el tutorial
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }

    // Detecta el movimiento del ratón
    bool DetectMouseMovement()
    {
        return Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f || Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.1f;
    }
}
