using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI powerText;
	[SerializeField] TextMeshProUGUI maxPowerText;

	void Awake()
	{
		powerText.text = "Power: " + PlayerPrefs.GetInt("Power").ToString();
		maxPowerText.text = "Max power: " + PlayerPrefs.GetInt("MaxPower").ToString();
	}
}
