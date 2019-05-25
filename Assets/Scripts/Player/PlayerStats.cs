using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float vida = 100;
    public bool isDying = false;

    public MovementInput movePlayer;

    private void Update()
    {
        Respawn();
    }

    void Respawn()
    {
        if(vida <= 0 && isDying == false)
        {
            StartCoroutine(movePlayer.RespawnPlayer());
        }
    }

}
