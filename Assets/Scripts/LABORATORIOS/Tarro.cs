using UnityEngine;

public class Tarro : MonoBehaviour
{
    public enum Compuesto { Hidrogeno, Ferrium, Clorina, Oxigeno, Ninguno }
    public Compuesto compuestoActual = Compuesto.Ninguno;

    public Color colorVisual;
    public AudioClip sonidoTarro;
    private AudioSource audioSource;

    public bool haExplotado = false;  // Variable que indica si el tarro ha explotado
    public bool puedeInteractuar = true;  // Variable para controlar si el tarro puede ser interactuado

    private void Start()
    {
        GetComponent<Renderer>().material.color = colorVisual;
        audioSource = GetComponent<AudioSource>();
    }

    public void Seleccionar()
    {
        if (!puedeInteractuar || haExplotado)
            return;

        if (sonidoTarro != null && audioSource != null)
        {
            audioSource.PlayOneShot(sonidoTarro);
        }

        bool fueMezcla = MezclaManager.Instance.SeleccionarTarro(this);

        if (fueMezcla)
        {
            UIInteraccion.instancia.MostrarMensaje("Mezcla realizada");
        }
        else
        {
            UIInteraccion.instancia.MostrarMensaje("Tienes el compuesto " + compuestoActual);
        }
    }

    private void OnMouseDown()
    {
        // Si el tarro no puede ser interactuado, no permitir selecci�n
        if (!puedeInteractuar || haExplotado)
            return;

        Seleccionar();
    }

    // M�todo para manejar la explosi�n
    public void Explotar()
    {
        haExplotado = true;
        // Aqu� puedes agregar efectos visuales o sonidos para la explosi�n si lo deseas
        Debug.Log("�El tarro ha explotado!");

        // Desactivar la interacci�n despu�s de la explosi�n
        puedeInteractuar = false;
    }

    // M�todo para reiniciar el tarro (cuando el sistema se reinicia)
    public void Reiniciar()
    {
        haExplotado = false;
        puedeInteractuar = true;
        // Aqu� puedes reiniciar otros aspectos como color, posici�n, etc.
    }
}
