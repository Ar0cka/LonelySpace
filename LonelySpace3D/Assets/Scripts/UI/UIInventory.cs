using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private ItemInfo _apple;
    [SerializeField] private ItemInfo _pepper;

    public InventoryWithSlot inventory => tester.inventory;
    private UIInventoryTester tester;

    private void Start()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        tester = new UIInventoryTester(_apple, _pepper, uiSlots);
        tester.FillsSlots();
    }
}
