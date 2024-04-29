using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ArmorPowerUp : Powerup
{
    public float armorToAdd;
    public override void Apply(PowerupManager target)
    {
        Armor targetArmor = target.GetComponent<Armor>();
        if (targetArmor != null)
        {
            // The second parameter is the pawn who caused the healing - in this case, they healed themselves
            targetArmor.Armorize(armorToAdd, target.GetComponent<Pawn>());
        }
    }

    public override void Remove(PowerupManager target)
    {
        // TODO: Remove Health changes
    }
}
