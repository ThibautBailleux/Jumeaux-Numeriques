using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Si vous souhaitez afficher dans l'UI

public class WindTurbineDisplay : MonoBehaviour
{
    public WindTurbineData turbineData;  // Référence à un ScriptableObject WindTurbineData
    public Text turbineIdText;
    public Text windSpeedText;
    public Text powerText;

    void Start()
    {
        if (turbineData != null)
        {
            DisplayTurbineData();
        }
    }

    void DisplayTurbineData()
    {
        turbineIdText.text = "Turbine ID: " + turbineData.turbineId;
        windSpeedText.text = "Wind Speed: " + turbineData.windSpeed + " m/s";
        powerText.text = "Power: " + turbineData.power + " kW";
    }
}
