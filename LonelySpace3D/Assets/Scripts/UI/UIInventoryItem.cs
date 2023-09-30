using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : UIItem
{
    [SerializeField] private Image _imageIcone;
    [SerializeField] private TextMeshProUGUI _textAmount;

    public IInventoryItem item { get; private set; }
    public void Refresh(IInventorySlot slot)
    {
        if (slot.isEmpty)
        {
            Cleanup();
            return;
        }

        item = slot.item;
        _imageIcone.sprite = item.info.spriteIcon;

        var textAmountEnabled = slot.amount > 1;
        _textAmount.gameObject.SetActive(textAmountEnabled);

        if (textAmountEnabled)
            _textAmount.text = $"x{slot.amount.ToString()}";

    }

    private void Cleanup()
    {
        _textAmount.gameObject.SetActive(false);
        _imageIcone.gameObject.SetActive(false);
    }
}
