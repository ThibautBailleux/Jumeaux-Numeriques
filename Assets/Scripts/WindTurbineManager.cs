using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbineManager : MonoBehaviour
{
    public GameObject turbinePrefab;  // Préfabriqué pour la turbine
    public WindTurbineData[] turbinesData;  // Tableau de toutes les données des turbines

    void Start()
    {
        foreach (WindTurbineData turbineData in turbinesData)
        {
            CreateTurbine(turbineData);
        }
    }

    void CreateTurbine(WindTurbineData turbineData)
    {
        // Instancier un nouveau GameObject pour chaque turbine
        GameObject turbineGO = Instantiate(turbinePrefab, transform.position, Quaternion.identity);
        WindTurbineDisplay display = turbineGO.GetComponent<WindTurbineDisplay>();
        display.turbineData = turbineData;  // Assigner les données à chaque turbine
    }
}
