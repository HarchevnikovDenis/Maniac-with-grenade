using System;

public class Slot
{
    public readonly GrenadeType grenadeType;

    private SlotUI slotUI;
    private int itemCount;

    public bool IsEmpty => itemCount.Equals(0);

    public Slot(GrenadeType grenadeType, int slotIndex)
    {
        this.grenadeType = grenadeType;
        itemCount = 0;

        InitSlotUI(slotIndex);
    }

    private void InitSlotUI(int slotIndex)
    {
        slotUI = UIManager.Instance.GetSlotUI(slotIndex);
        if (!slotUI) throw new NullReferenceException();

        slotUI.InitSlotUI(grenadeType, itemCount);
    }

    public void AddGrenadeCount()
    {
        itemCount++;
        slotUI.SetItemCount(itemCount);
    }

    public void DecreaseGrenadeCount()
    {
        itemCount--;
        if (itemCount < 0) itemCount = 0;

        slotUI.SetItemCount(itemCount);
    }

    public void SetSlotSelected(bool isSelected)
    {
        slotUI.SetSlotSelectedUI(isSelected);
    }
}
