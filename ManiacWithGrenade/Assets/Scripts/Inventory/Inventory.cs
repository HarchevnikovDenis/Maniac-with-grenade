using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Slot> slots;

    private int selectedSlotIndex;
    private Slot selectedSlot
    {
        get
        {
            if (selectedSlotIndex >= slots.Count || selectedSlotIndex < 0)
            {
                return null;
            }
            else
            {
                return slots[selectedSlotIndex];
            }
        }
    }

    public GrenadeType CurrentGrenadeType
    {
        get
        {
            if (!selectedSlot.Equals(null))
            {
                return selectedSlot.grenadeType;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
    }

    public bool IsCurrentSelectedSlotEmpty => selectedSlot.IsEmpty;

    public void InitInventory()
    {
        // Init slots
        slots = new List<Slot>();

        Slot redSlot = new Slot(GrenadeType.RED, 0);
        Slot greenSlot = new Slot(GrenadeType.GREEN, 1);
        Slot blueSlot = new Slot(GrenadeType.BLUE, 2);

        slots.Add(redSlot);
        slots.Add(greenSlot);
        slots.Add(blueSlot);

        SetSelectedSlotWithIndex(0);
    }

    public void ChangeSelectedSlot(bool isRightMoving)
    {
        if (isRightMoving)
        {
            if (selectedSlotIndex < slots.Count - 1)
            {
                SetSelectedSlotWithIndex(selectedSlotIndex + 1);
            }
        }
        else
        {
            if (selectedSlotIndex > 0)
            {
                SetSelectedSlotWithIndex(selectedSlotIndex - 1);
            }
        }
    }

    public void AddGrenadeWithType(GrenadeType grenadeType)
    {
        Slot slot = slots.Find(t => t.grenadeType.Equals(grenadeType));
        if (slot.Equals(null)) throw new NullReferenceException();

        slot.AddGrenadeCount();
    }

    public void DecreaseGrenade()
    {
        selectedSlot.DecreaseGrenadeCount();
    }

    public bool IsNullGrenadeCount(GrenadeType grenadeType)
    {
        Slot slot = slots.Find(t => t.grenadeType.Equals(grenadeType));
        if (slot.Equals(null)) throw new NullReferenceException();

        return slot.IsEmpty;
    }

    private void SetSelectedSlotWithIndex(int index)
    {
        selectedSlot?.SetSlotSelected(false);
        selectedSlotIndex = index;

        selectedSlot.SetSlotSelected(true);
    }
}
