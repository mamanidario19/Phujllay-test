using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI missionText;
    [SerializeField] private List<Mission> staticMissions = new List<Mission>();
    [SerializeField] private GameObject panel;
    
    private void UpdateMissionUI()
    {
        missionText.text = GetMissionText();
    }

    //private void Start()
    //{
    //    staticMissions.Add(new Mission("Comenzamos", "Dirigete al siguiente punto", enum_MissionStatus.InProgress, enum_MissionType.Main, 0, 0));

    //    staticMissions.Add(new Mission("Primera Travesura!", "Persigue al duendecillo", enum_MissionStatus.InProgress, enum_MissionType.Main, 0, 0));

    //    staticMissions.Add(new Mission("El pedido de la artesana", "Encuentra al tecnico", enum_MissionStatus.Available, enum_MissionType.Main, 0, 0));

    //    staticMissions.Add(new Mission("Ayuda a la Pachamama", "Purifica los espiritus negativos", enum_MissionStatus.Available, enum_MissionType.Main, 0, 4));
    //}

    private string GetMissionText()
    {
        string missionInfo = "";

        foreach (Mission mission in staticMissions)
        {
            if (mission.Status == enum_MissionStatus.Available) // Filtra solo misiones disponibles
            {
                string progressText = "";

                if (mission.ProgressTotal > 0 && mission.ProgressCurrent >= 0) // Verifica si la mision tiene progreso
                {
                    progressText = $" - Progreso: {mission.ProgressCurrent}/{mission.ProgressTotal}";
                }
                missionInfo += $"{mission.MissionName}: {mission.Description}{progressText}\n";
            }
        }

        return missionInfo;
    }

    private void IncreaseMissionProgress(string missionName)
    {
        Mission mission = staticMissions.Find(m => m.MissionName == missionName);
        if (mission != null && mission.ProgressCurrent < mission.ProgressTotal)
        {
            mission.ProgressCurrent++;
            UpdateMissionUI(); // Actualiza el texto en el HUD
            Debug.Log($"Progreso de misión: '{mission.MissionName}' ---->{mission.ProgressCurrent}/{mission.ProgressTotal}");

            if (mission.ProgressCurrent >= mission.ProgressTotal) // Verifica si la misión está completada
            {
                mission.Status = enum_MissionStatus.Completed;
                Debug.Log($"Misión '{mission.MissionName}' completada!!!");
            }
        }
    }
}
