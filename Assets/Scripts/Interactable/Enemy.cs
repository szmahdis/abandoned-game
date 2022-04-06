using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//should be Enemy : Interactable
[RequireComponent(typeof(CharacterCombat))]
public class Enemy : Interactable
{
    PlayerManager playerManager;

    CharacterStats myStats;

    CharacterCombat enemyCombat;

    public CharacterStats playerStats;

    void Start()
    {
        //base.Start();
        playerManager = PlayerManager.instace;
        myStats = GetComponent<CharacterStats>();
        base.player = PlayerManager.instace.player.transform;
        enemyCombat = GetComponent<CharacterCombat>();

        //base.player = 
    }


    public override void Interact()
    {
        base.Interact();

        //Attack the player
        //CharacterCombat playerCombat =  playerManager.player.GetComponent<CharacterCombat>();
        
        if(enemyCombat != null)
        {
            enemyCombat.Attack(playerStats);
        }
        
        /*
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
        */

    }




    //UnityEngine.Int

    //public override 
}
