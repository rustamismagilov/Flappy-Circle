using UnityEngine;

public class Coin : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float minXPosition = -10f; // The X coordinate where coins should respawn
    public int coinValue = 1; // The value of the coin when collected

    private void Update()
    {
        // Move the coin from right to left along the X-axis
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        
    }


    

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the coin has collided with the main character
        if (other.CompareTag("Player"))
        {
            // Call a method to handle the coin collection
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        // Destroy the coin GameObject after collection
        Destroy(gameObject);
    }
}
