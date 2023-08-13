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

        // Respawn the coin if it goes beyond minXPosition
        if (transform.position.x <= minXPosition)
        {
            RespawnCoin();
        }
    }

    private void RespawnCoin()
    {
        // Randomly determine the Y position within the desired range
        float newYPosition = Random.Range(-4.35f, 4.35f);

        // Move the coin outside the screen on the opposite side
        float newPosX = 10f; // The X coordinate where coins should respawn
        transform.position = new Vector3(newPosX, newYPosition, transform.position.z);
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
