using UnityEngine;

public class BotonEmergenciaFisico : MonoBehaviour
{
    public float rangoInteraccion = 3f;
    private Transform jugador;
    private bool jugadorCerca = false;

    public AudioSource audioSource;  // Agrega esta variable para el AudioSource
    public AudioClip sonidoBoton;   // Asigna el sonido en el Inspector

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>(); // Asegurarse de tener el AudioSource

        if (audioSource != null && sonidoBoton != null)
            audioSource.clip = sonidoBoton;
    }

    void Update()
    {
        // Verificar la distancia entre el jugador y el botón de emergencia
        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Si la mezcla explotó y el jugador está cerca del botón
        if (MezclaManager.Instance.Exploto() && distancia <= rangoInteraccion)
        {
            if (!jugadorCerca)
            {
                jugadorCerca = true;
                UIInteraccion.instancia.MostrarMensaje("Presiona E para reiniciar");
            }

            // Cuando el jugador presiona E, se reinicia el sistema
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (audioSource != null && sonidoBoton != null)
                {
                    audioSource.PlayOneShot(sonidoBoton);  // Reproduce el sonido
                }
                MezclaManager.Instance.ReiniciarSistema();
                UIInteraccion.instancia.OcultarMensaje();
            }
        }
        else
        {
            // Si el jugador se aleja o la mezcla no ha explotado, se oculta el mensaje
            if (jugadorCerca)
            {
                jugadorCerca = false;
                UIInteraccion.instancia.OcultarMensaje();
            }
        }
    }
}
