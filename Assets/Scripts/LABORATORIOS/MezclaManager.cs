using UnityEngine;
using System.Collections.Generic;

public class MezclaManager : MonoBehaviour
{
    public static MezclaManager Instance;

    private Tarro primerSeleccionado;
    private Tarro segundoSeleccionado;

    public Tarro tarroResultado;

    private Dictionary<(Tarro.Compuesto, Tarro.Compuesto), Color> mezclasColores;

    [Header("Efectos de mezcla")]
    public AudioSource audioSource;
    public AudioClip sonidoMezcla;
    public AudioClip sonidoExplosion;
    public GameObject efectoExplosion; // VFX de la explosión

    // Hacer privada la variable de estado de la explosión
    private bool mezclaExplotada = false;

    private void Awake()
    {
        Instance = this;

        // Define mezclas posibles
        mezclasColores = new Dictionary<(Tarro.Compuesto, Tarro.Compuesto), Color>
        {
            { (Tarro.Compuesto.Hidrogeno, Tarro.Compuesto.Ferrium), Color.magenta },
            { (Tarro.Compuesto.Clorina, Tarro.Compuesto.Ferrium), Color.yellow },
            { (Tarro.Compuesto.Hidrogeno, Tarro.Compuesto.Clorina), Color.cyan },
            { (Tarro.Compuesto.Oxigeno, Tarro.Compuesto.Ferrium), new Color(1f, 0.5f, 0.5f) },
            // Agrega más combinaciones según quieras
        };
    }

    public void SeleccionarTarro(Tarro tarro)
    {
        if (mezclaExplotada) return; // Si la mezcla explotó, no se puede seguir interactuando

        if (primerSeleccionado == null)
        {
            primerSeleccionado = tarro;
        }
        else if (segundoSeleccionado == null && tarro != primerSeleccionado)
        {
            segundoSeleccionado = tarro;
            MezclarCompuestos();
        }
    }

    private void MezclarCompuestos()
    {
        var comp1 = primerSeleccionado.compuestoActual;
        var comp2 = segundoSeleccionado.compuestoActual;

        var key1 = (comp1, comp2);
        var key2 = (comp2, comp1);

        // EXPLOSIÓN: Hidrógeno + Oxígeno
        if ((comp1 == Tarro.Compuesto.Hidrogeno && comp2 == Tarro.Compuesto.Oxigeno) ||
    (comp1 == Tarro.Compuesto.Oxigeno && comp2 == Tarro.Compuesto.Hidrogeno))
        {
            tarroResultado.GetComponent<Renderer>().material.color = Color.black;

            if (sonidoExplosion != null && audioSource != null)
                audioSource.PlayOneShot(sonidoExplosion);

            if (efectoExplosion != null)
            {
                efectoExplosion.transform.position = tarroResultado.transform.position;
                efectoExplosion.SetActive(true); // Solo lo activamos
            }

            mezclaExplotada = true;
            return;
        }

        else if (mezclasColores.ContainsKey(key1))
        {
            tarroResultado.GetComponent<Renderer>().material.color = mezclasColores[key1];
            if (audioSource != null && sonidoMezcla != null)
                audioSource.PlayOneShot(sonidoMezcla);
        }
        else if (mezclasColores.ContainsKey(key2))
        {
            tarroResultado.GetComponent<Renderer>().material.color = mezclasColores[key2];
            if (audioSource != null && sonidoMezcla != null)
                audioSource.PlayOneShot(sonidoMezcla);
        }
        else
        {
            // Si no hay combinación definida, color neutro
            tarroResultado.GetComponent<Renderer>().material.color = Color.gray;
            if (audioSource != null && sonidoMezcla != null)
                audioSource.PlayOneShot(sonidoMezcla);
        }

        // Restablecer las selecciones para permitir otra mezcla
        primerSeleccionado = null;
        segundoSeleccionado = null;
    }

    // Método para obtener el estado de la explosión
    public bool Exploto()
    {
        return mezclaExplotada;
    }

    // Método para establecer el estado de la explosión
    public void EstablecerExplosión(bool estado)
    {
        mezclaExplotada = estado;
    }

    public void ReiniciarSistema()
    {
            // Reiniciar selección
            primerSeleccionado = null;
            segundoSeleccionado = null;

            // Resetear el color del tarro de mezcla
            if (tarroResultado != null)
            {
                Renderer rend = tarroResultado.GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material.color = Color.white; // o el color original que quieras
                }

                // Reactivar el tarro si estaba desactivado
                tarroResultado.gameObject.SetActive(true);
            }

            // Volver a permitir interacciones
            mezclaExplotada = false;

            // Reactivar todos los tarros
            Tarro[] todosLosTarros = FindObjectsOfType<Tarro>();
            foreach (var t in todosLosTarros)
            {
                t.puedeInteractuar = true;
            }

        // Si el GameObject VFX está asignado, lo desactivamos
        if(efectoExplosion != null)
{
            efectoExplosion.SetActive(false); // Lo apagamos para que esté listo para la próxima explosión
        }
        Debug.Log("Sistema reiniciado por el botón de emergencia.");

    }
}
