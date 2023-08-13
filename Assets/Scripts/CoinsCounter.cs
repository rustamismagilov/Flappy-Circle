using UnityEngine;
using UnityEngine.UI;

public class CoinsCounter : MonoBehaviour
{
    public static CoinsCounter instance;

    public Text coinsText; // Reference to the Text component
    public int currentCoins = 0; // Initialize coin count to zero

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Make sure that the coinsText field is properly set in the Inspector
        if (coinsText != null)
        {
            // Update the Text component with the current coin count
            coinsText.text = "Coins collected: " + currentCoins.ToString();
        }
        else
        {
            Debug.LogError("CoinsText field not assigned in the Inspector!");
        }
    }

    // Method to increment the coin count
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        // Update the displayed coin count
        if (coinsText != null)
        {
            coinsText.text = "Coins collected: " + currentCoins.ToString();
        }
        else
        {
            Debug.LogError("CoinsText field not assigned in the Inspector!");
        }
    }
}
