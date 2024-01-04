using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    [SerializeField] private string nameItem;

    public string NameItem
    {
        get { return nameItem; }
        set { nameItem = value; }
    }

    [SerializeField] private string description;

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    [SerializeField] private bool consumable;

    public bool Consumable
    {
        get { return consumable; }
        set { consumable = value; }
    }

    [SerializeField] private bool equippable;

    public bool Equippable { 
        get { return equippable; }
        set {  equippable = value; }
    }

    [SerializeField] private Sprite image;

    public Sprite Image
    {
        get { return image; }
        set { image = value; }
    }
}
