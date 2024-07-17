using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] private string missionName;
    [SerializeField] private string description;
    [SerializeField] private enum_MissionStatus status;
    [SerializeField] private enum_MissionType type;
    [SerializeField] private int progressCurrent;
    [SerializeField] private int progressTotal;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject previous;

    public Mission(string name, string description, enum_MissionStatus status, enum_MissionType type, int progressCurrent = 0, int progressTotal = 1)
    {
        this.missionName = name;
        this.description = description;
        this.status = status;
        this.type = type;
        this.progressCurrent = progressCurrent;
        this.progressTotal = progressTotal;
    }

    public string MissionName
    {
        get { return missionName; }
        set { missionName = value; }
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public enum_MissionStatus Status
    {
        get { return status; }
        set { status = value; }
    }

    public enum_MissionType Type
    {
        get { return type; }
        set { type = value; }
    }

    public int ProgressCurrent
    {
        get { return progressCurrent; }
        set { progressCurrent = value; }
    }

    public int ProgressTotal
    {
        get { return progressTotal; }
        set { progressTotal = value; }
    }

    public void Destruir()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(previous != null)
            {
                previous.GetComponent<Mission>().Destruir();
            }

            panel.SetActive(true);
        }
    }
}