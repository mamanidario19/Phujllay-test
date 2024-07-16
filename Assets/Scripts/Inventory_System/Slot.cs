using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int Id;
    public string nameObject;
    public string type;
    public string description;
    

    public bool empty;
    public Sprite icon;

    public Transform slotIconGameObject;
    public Button slotButton;

    private void Start()
    {
        slotIconGameObject = transform.GetChild(0);
        slotButton = GetComponent<Button>();
        slotButton.onClick.AddListener(OnSlotClicked);
    }

    public void UpdateSlot()
    {
        slotIconGameObject.GetComponent<Image>().sprite=icon;

    }
    
    private void OnSlotClicked()
    {
        if (!empty)
        {
            InventoryManager.instance.ShowItemInfo(nameObject, description);
        }
    }
}
