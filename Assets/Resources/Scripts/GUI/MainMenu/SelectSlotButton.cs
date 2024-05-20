using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class SelectSlotButton : AbstractBaseButton
{
    [SerializeField] private int slotId;
    protected override void OnClick()
    {
        UserInputChanel selectSlot = new(UserInputChanel.SELECT_SLOT_CLICK, slotId);
        ObserverManager.TriggerEvent<UserInputChanel>(selectSlot);
    }

}
