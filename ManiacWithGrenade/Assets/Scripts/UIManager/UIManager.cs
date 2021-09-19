using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private List<SlotUI> slotsUI;

    public SlotUI GetSlotUI(int index)
    {
        if (index < 0 || index >= slotsUI.Count) throw new NullReferenceException();

        return slotsUI[index];
    }
}
