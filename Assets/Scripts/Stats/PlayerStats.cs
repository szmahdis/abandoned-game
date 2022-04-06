using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.instace.KillPlayer();
    }
}
