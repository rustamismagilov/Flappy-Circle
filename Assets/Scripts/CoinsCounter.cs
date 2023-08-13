using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter instance;

    public TMP_Text coinsText; // Reference to the TMPro Text component
    private int currentCoins = 0; // Initialize coin count to zero

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Update the Text component with the current coin count
        coinsText.text = "Coins collected: " + currentCoins.ToString();
    }


    // Method to increment the coin count
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinsText.text = "Coins collected: " + currentCoins.ToString();
    }
}
