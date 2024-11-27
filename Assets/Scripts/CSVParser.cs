using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;  // Nécessaire pour AssetDatabase
using System.IO;

public class CSVParser : MonoBehaviour
{
    public TextAsset data; // Le fichier CSV à importer
    public string dataFolderPath = "Assets/Resources/WindTurbines"; // Dossier pour sauvegarder les ScriptableObjects

    void Start()
    {
        if (data != null)
        {
            ParseCSV();
        }
        else
        {
            Debug.LogError("Le fichier CSV est manquant !");
        }
    }

    void ParseCSV()
    {
        // S'assurer que le dossier existe, sinon le créer
        if (!Directory.Exists(dataFolderPath))
        {
            Directory.CreateDirectory(dataFolderPath);
        }

        // Lire toutes les lignes du fichier CSV
        string[] lines = data.text.Split('\n');

        // Dictionnaire pour regrouper les données par turbineId
        Dictionary<string, List<WindTurbineData>> turbinesData = new Dictionary<string, List<WindTurbineData>>();

        // Sauter la première ligne (les en-têtes)
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i].Trim();
            if (string.IsNullOrEmpty(line)) continue;

            string[] values = line.Split(',');

            // Créer et sauvegarder un ScriptableObject pour chaque ligne
            if (values.Length >= 8)
            {
                string turbineId = values[0];
                WindTurbineData turbineData = CreateWindTurbineData(values);

                // Ajouter les données dans le dictionnaire
                if (!turbinesData.ContainsKey(turbineId))
                {
                    turbinesData[turbineId] = new List<WindTurbineData>();
                }

                turbinesData[turbineId].Add(turbineData);
            }
        }

        // Sauvegarder les données dans des ScriptableObjects
        foreach (var turbineId in turbinesData.Keys)
        {
            SaveWindTurbineData(turbineId, turbinesData[turbineId]);
        }
    }

    // Créer un objet WindTurbineData à partir des valeurs CSV
    WindTurbineData CreateWindTurbineData(string[] values)
    {
        WindTurbineData turbineData = ScriptableObject.CreateInstance<WindTurbineData>();

        turbineData.turbineId = values[0];
        turbineData.timeInterval = values[1];
        turbineData.eventCode = values[2];
        turbineData.eventCodeDescription = values[3];
        turbineData.windSpeed = float.Parse(values[4]);
        turbineData.ambientTemperature = float.Parse(values[5]);
        turbineData.rotorSpeed = float.Parse(values[6]);
        turbineData.power = float.Parse(values[7]);

        return turbineData;
    }

    // Sauvegarder les données de la turbine dans un fichier .asset
    void SaveWindTurbineData(string turbineId, List<WindTurbineData> turbineDataList)
    {
        string path = $"{dataFolderPath}/{turbineId}.asset";
        AssetDatabase.CreateAsset(turbineDataList[0], path); // On enregistre seulement la première turbine de chaque groupe
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}