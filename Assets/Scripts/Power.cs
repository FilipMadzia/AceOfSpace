using TMPro;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public void IncreasePower()
    {
        var power = player.GetComponent<PlayerShooting>().IncreasePower();
        GetComponent<TextMeshProUGUI>().text = "Power: " + power.ToString();
    }
}
