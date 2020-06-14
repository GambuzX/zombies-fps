using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType type) {
        AmmoSlot slot = GetAmmoSlot(type);
        return slot == null ? 0 : slot.ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType type) {
        AmmoSlot slot = GetAmmoSlot(type);
        if (slot != null)
            slot.ammoAmount--;
    }

    public void AddAmmo(AmmoType type, int amount) {
        AmmoSlot slot = GetAmmoSlot(type);
        if (slot != null)
            slot.ammoAmount += amount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType type) {
        foreach(AmmoSlot slot in ammoSlots) {
            if (slot.ammoType == type)
                return slot;
        }
        return null;
    }
}
