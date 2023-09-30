using System;
using Unity.VisualScripting;

public interface IInventoryItem
{
    IInventoryItemInfo info { get; }
    IInventoryItemState state { get; }  

    Type type { get; } //���� ��������

    IInventoryItem Clone(); // ������������ ��������

}
