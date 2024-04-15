using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission
{
    public string name;
    public string description;
    public enum_MissionStatus status;
    public enum_MissionType type;
    public int progressCurrent;
    public int progressTotal;

    public Mission(string name, string description, enum_MissionStatus status, enum_MissionType type, int progressCurrent = 0, int progressTotal = 1)
    {
        this.name = name;
        this.description = description;
        this.status = status;
        this.type = type;
        this.progressCurrent = progressCurrent;
        this.progressTotal = progressTotal;
    }
}