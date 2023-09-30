using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryTester {

    private ItemInfo _appleInfo;
    private ItemInfo _pepperInfo;
    private UIInventorySlot[] _uiSlots;

    public InventoryWithSlot inventory { get; }

    public UIInventoryTester(ItemInfo appleInfo, ItemInfo pepperInfo, UIInventorySlot[] uiSlots)
    {
        _appleInfo = appleInfo;
        _pepperInfo = pepperInfo;   
        _uiSlots = uiSlots;

        inventory = new InventoryWithSlot(14);
        inventory.OnInventoryStateChangeEvent += OnInventoryStateChangeEvent;
    }

    public void FillsSlots()
    {
        var allSlots = inventory.GetAllSlots();
        var availableSlots = new List<IInventorySlot>(allSlots);

        var filledSlots = 5;
        for (int i = 0; i < filledSlots; i++)
        {
            var filledSlot = AddRandomApplesIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);

            filledSlot = AddRandomPepperIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
        }

        SetupInventoryUI(inventory);
    }

    private void SetupInventoryUI(InventoryWithSlot inventoryWithSlot)
    {
        var allSlots = inventoryWithSlot.GetAllSlots();
        var allSlotsCount = allSlots.Length;
        for (int i = 0; i < allSlotsCount; i++)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }

    private IInventorySlot AddRandomApplesIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotsIndex = Random.Range(0, slots.Count);
        var rSlot = slots[rSlotsIndex];
        var rCount = Random.Range(1, 4);
        var apple = new Apple(_appleInfo);
        apple.state.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, apple);
        return rSlot;
    }
    private IInventorySlot AddRandomPepperIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotsIndex = Random.Range(0, slots.Count);
        var rSlot = slots[rSlotsIndex];
        var rCount = Random.Range(1, 4);
        var pepper = new Pepper(_pepperInfo);
        pepper.state.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, pepper);
        return rSlot;
    }

    private void OnInventoryStateChangeEvent(object obj)
    {
        foreach (var slot in _uiSlots)
        {
            slot.Refresh();
        }
    }
}
