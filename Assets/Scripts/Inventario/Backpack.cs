using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] private List<ItemData> items = new List<ItemData>();
    [SerializeField] private GameObject menuItems;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowData();            
        }
    }

    public void AddItemToList(ItemData item)
    {
        items.Add(item);
    }

    public void ShowData()
    {
        if (items.Count <= 0)
        {
            Debug.Log("No hay items en el inventario");
            return;
        }

        menuItems.SetActive(!menuItems.activeSelf);

        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log("Nombre del objeto " + i + ": " + items[i].NameItem);
        }
    }
}
