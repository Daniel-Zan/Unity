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

    private bool isWaiting = false; //  NUEVO
    private bool mouseMoved = false;
    private bool movementKeysPressed = false;

    public Tacos tacos; // Referencia al script Tacos
    public GameObject tacosBlocker;
    void Start()
    {
        // Asegurarse de que solo el primer paso esté activo al inicio
        for (int i = 0; i < tutorialSteps.Length; i++)
        {
            tutorialSteps[i].SetActive(i == currentStep);
        }

        if (tacos != null)
        {
            // Escuchar el evento de interacción
            tacos.onInteract += OnTacosInteracted;
            tacos.DisableInteraction();

        }
    }

        void Update()
    {
        if (currentStep == 0 && !isWaiting)
        {
            isWaiting = true;
            StartCoroutine(WaitAndProceed(8f));
        }

        else if (currentStep == 1 && !mouseMoved)
        {
            if (DetectMouseMovement())
            {
                mouseMoved = true;
                StartCoroutine(WaitAfterAction(3f)); // Espera 3 segundos más después de mover el mouse
            }
        }

        else if (currentStep == 2 && !movementKeysPressed)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                movementKeysPressed = true;
                StartCoroutine(WaitAfterAction(5f)); // Espera 3 segundos después de moverse
            }
        }

        else if (currentStep == 3 )
        {

            if (tacosBlocker != null)
            {
                tacosBlocker.SetActive(false); // Quitar la barrera
            }
            
        }


        else if (currentStep == 4 )
        {
            //Desactivar el movimiento del jugador y esperar
            if (playerMovementScript != null)
            {
               playerMovementScript.enabled = false; // Desactiva el movimiento
            }
            StartCoroutine(WaitAndProceed(8f)); // Esperar 5 segundos antes de avanzar al siguiente paso
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SkipTutorial();
        }
    }


    IEnumerator WaitAfterAction(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NextStep();
    }
    IEnumerator WaitAndProceed(float waitTime)
    {
        // Mostrar el paso actual
        tutorialSteps[currentStep].SetActive(true);

        // Esperar los segundos que se pasen como parámetro
        yield return new WaitForSeconds(waitTime);

        isWaiting = false;
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

        void OnTacosInteracted()
        {
            // Avanza de paso cuando el jugador interactúa con los tacos en el paso 3
            if (currentStep == 3)
            {
            StartCoroutine(WaitAfterAction(5f));
            NextStep();
            }
        }
    }
