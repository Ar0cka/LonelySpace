
using System;
using Unity.VisualScripting;

public interface IInventory  {
  
    int capacity { get; set; } // ����� ���������
    bool isFull { get; } // �������� �� ������������� ���������

    IInventoryItem GetItem(Type itemType); //����� ��������
    IInventoryItem[] GetAllItems(); // ����� ���� ���������
    IInventoryItem[] GetAllItems(Type itemType); // ����� ��������� ������������� ����
    IInventoryItem[] GetEquippedItems(); // ������� �������� ��� �������������� ���������
    int GetItemAmount(Type itemType); // ������� ����������

    bool TryToAdd(object sender, IInventoryItem item); // �������� �� ��, ������� �� ��������� ��������, sender ���������, ������ ������� ��� ����.
    void Remove(object sender, Type itemType, int amount = 1); // �������� ��������� ������������� ����

    bool HasItem(Type type, out IInventoryItem item); // �������� ������������� �������� ������������� ����



}
