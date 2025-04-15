using UnityEngine;

public class InteraccionPorProximidad : MonoBehaviour
{
    public float rangoInteraccion = 3f;
    private Transform jugador;
    private Tarro tarro;
    private bool jugadorCerca = false;

    private void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        tarro = GetComponent<Tarro>();
    }

    private void Update()
    {
        if (MezclaManager.Instance != null && MezclaManager.Instance.Exploto())
        {
            if (jugadorCerca)
            {
                jugadorCerca = false;
                UIInteraccion.instancia.OcultarMensaje(); // Oculta si aún se está mostrando
            }
            return; // No hace nada más
        }


        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia <= rangoInteraccion)
        {
            if (!jugadorCerca)
            {
                jugadorCerca = true;
                UIInteraccion.instancia.MostrarMensaje("Presiona E para agarrar");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                tarro.Seleccionar();
            }
        }
        else
        {
            if (jugadorCerca)
            {
                jugadorCerca = false;
                UIInteraccion.instancia.OcultarMensaje();
            }
        }
    }
}
