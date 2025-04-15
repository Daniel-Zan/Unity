using UnityEngine;
using TMPro;

public class UIInteraccion : MonoBehaviour
{
    public static UIInteraccion instancia;
    public TextMeshProUGUI textoInteraccion;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }

    public void MostrarMensaje(string mensaje)
    {
        textoInteraccion.text = mensaje;
        textoInteraccion.gameObject.SetActive(true);
    }

    public void OcultarMensaje()
    {
        textoInteraccion.gameObject.SetActive(false);
    }
}
