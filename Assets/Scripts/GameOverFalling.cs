using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverFalling : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Game Over!");
        }
    }
}
