using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionHUD : MonoBehaviour
{
    public TextMeshProUGUI missionText;

    private void Update()
    {
        UpdateMissionUI();

        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseMissionProgress("Ayuda a la Pachamama");
        }
    }

    private void UpdateMissionUI()
    {
        missionText.text = GetMissionText();
    }
    private List<Mission> staticMissions = new List<Mission>(); // 

    private void Start()
    {
        // Misiones iniciales
        staticMissions.Add(new Mission("Primera Travesura!", "Persigue al duendecillo", enum_MissionStatus.InProgress, enum_MissionType.Main,0,0));
        staticMissions.Add(new Mission("El pedido de la artesana", "Encuentra al tecnico", enum_MissionStatus.Available, enum_MissionType.Main,0,0));
        staticMissions.Add(new Mission("Ayuda a la Pachamama", "Purifica los espiritus negativos", enum_MissionStatus.Available, enum_MissionType.Main, 0,4));

    }

  private string GetMissionText()
{
    string missionInfo = "";
    foreach (Mission mission in staticMissions)
    {
        if (mission.status == enum_MissionStatus.Available) // Filtra solo misiones disponibles
        {
            string progressText = "";
            if (mission.progressTotal > 0 && mission.progressCurrent >= 0) // Verifica si la mision tiene progreso
            {
                progressText = $" - Progreso: {mission.progressCurrent}/{mission.progressTotal}";
            }
            missionInfo += $"{mission.name}: {mission.description}{progressText}\n"; 
        }
    }
    return missionInfo;
}
private void IncreaseMissionProgress(string missionName)
    {
        Mission mission = staticMissions.Find(m => m.name == missionName);
        if (mission != null && mission.progressCurrent < mission.progressTotal)
        {
            mission.progressCurrent++;
            UpdateMissionUI(); // Actualiza el texto en el HUD
            Debug.Log($"Progreso de misión: '{mission.name}' ---->{mission.progressCurrent}/{mission.progressTotal}");

            if (mission.progressCurrent >= mission.progressTotal) // Verifica si la misión está completada
            {
                mission.status = enum_MissionStatus.Completed;
                Debug.Log($"Misión '{mission.name}' completada!!!");
            }
        }
    }

private void FailedMission()
    {
    }
}

