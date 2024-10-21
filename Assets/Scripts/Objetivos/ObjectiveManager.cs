using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    // Referencia al campo de texto en el Canvas
    public TextMeshProUGUI objectivesText;

    // Función para actualizar el texto de los objetivos
    public void UpdateObjective(string newObjective)
    {
        objectivesText.text = newObjective;  // Reemplazar el texto actual con el nuevo objetivo
    }
}
