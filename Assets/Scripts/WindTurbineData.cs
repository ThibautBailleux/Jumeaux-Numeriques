using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WindTurbineData", menuName = "WindTurbine/Data", order = 1)]
public class WindTurbineData : ScriptableObject
{
    public string turbineId;
    public string timeInterval;
    public string eventCode;
    public string eventCodeDescription;
    public float windSpeed;
    public float ambientTemperature;
    public float rotorSpeed;
    public float power;
}