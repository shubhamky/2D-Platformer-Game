﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
            
        }
    }
}