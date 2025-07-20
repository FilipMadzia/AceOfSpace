using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            var playerPower = GetComponent<PlayerShooting>().GetPower();
            PlayerPrefs.SetInt("Power", playerPower);

            if (playerPower > PlayerPrefs.GetInt("MaxPower"))
            {
                PlayerPrefs.SetInt("MaxPower", playerPower);
            }
            
            GetComponent<SceneManager>().LoadGameOver();
        }
    }
}
