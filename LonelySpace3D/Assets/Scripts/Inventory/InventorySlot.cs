

using System;

public class InventorySlot : IInventorySlot
{
    public bool isFull => amount == capacity; // ���� isFull ������ ��� ����� amount, ��� ���� amount = capacity, ����� true, ��� capacity - ��� ������������ ����� 

    public bool isEmpty => item == null; // isEmpty = true �����, ����� item == null;

    public IInventoryItem item { get; private set; } // �������� � ��������� ����������� � ��������� ����������

    public Type itemType => item.type; //itemType = ���� ��������

    public int amount => isEmpty ? 0 : item.amount; // ���� isEmpty ������� 0, ����� ����� �� ���������� null;

    public int capacity {get; private set;} // ����� �����

    public void Clear()
    {
        if (!isEmpty) return;

        item.amount = 0;
        item = null;
    }

    public void SetItem(IInventoryItem item)
    {
        if (!isEmpty) return;

        this.item = item;
        this.capacity = item.maxItemsInInventorySlot;
    }
}