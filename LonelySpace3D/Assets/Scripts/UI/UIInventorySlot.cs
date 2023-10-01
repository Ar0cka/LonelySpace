using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
    [SerializeField] private UIInventoryItem inventoryItem;

    public IInventorySlot slot { get; private set; }
    private UIInventory UiInventory;

    
    private void Awake()
    {
        UiInventory = GetComponentInParent<UIInventory>();
    }
    public void SetSlot(IInventorySlot newSlot)
    {
        this.slot = newSlot;
    }
    public override void OnDrop(PointerEventData eventData)
    {
        var otherItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
        var otherSlotUI = otherItemUI.GetComponentInParent<UIInventorySlot>();

        var otherSlot = otherSlotUI.slot;
        var inventory = UiInventory.inventory;

        inventory.TransitFromSlotToSlot(this, otherSlot, slot);

        Refresh();
        otherSlotUI.Refresh();
    }

    public void Refresh()
    {
        if (this.slot != null)
            inventoryItem.Refresh(slot);
    }
}
