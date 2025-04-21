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
        // Si el tarro no puede ser interactuado, no permitir selección
        if (!puedeInteractuar || haExplotado)
            return;

        Seleccionar();
    }

    // Método para manejar la explosión
    public void Explotar()
    {
        haExplotado = true;
        // Aquí puedes agregar efectos visuales o sonidos para la explosión si lo deseas
        Debug.Log("¡El tarro ha explotado!");

        // Desactivar la interacción después de la explosión
        puedeInteractuar = false;
    }

    // Método para reiniciar el tarro (cuando el sistema se reinicia)
    public void Reiniciar()
    {
        haExplotado = false;
        puedeInteractuar = true;
        // Aquí puedes reiniciar otros aspectos como color, posición, etc.
    }
}
