using UnityEngine;

public class Coin : MonoBehaviour
{
    public float xMoveSpeed = 2.0f; // Move speed along the X-axis
    public float yMoveSpeed = 1.0f; // Move speed along the Y-axis
    public float minYPosition = -4.35f;
    public float maxYPosition = 4.35f;
    public float minXPosition = -10f;

    private bool movingUp = true;

    public int coinValue = 1; // The value of the coin when collected

    private void Update()
    {
        // Move the coin from right to left along the X-axis
        transform.Translate(Vector3.left * xMoveSpeed * Time.deltaTime);

        // Calculate the new vertical position using yMoveSpeed
        float newYPosition = transform.position.y + (movingUp ? 1 : -1) * yMoveSpeed * Time.deltaTime;

        // Ensure the new position is within bounds
        newYPosition = Mathf.Clamp(newYPosition, minYPosition, maxYPosition);

        // Update the obstacle's position
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

        // Change movement direction if reached bounds
        if (newYPosition >= maxYPosition || newYPosition <= minYPosition)
        {
            movingUp = !movingUp;
        }
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
