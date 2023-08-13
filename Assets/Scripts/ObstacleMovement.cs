using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float xMoveSpeed = 2.0f; // Move speed along the X-axis
    public float yMoveSpeed = 1.0f; // Move speed along the Y-axis
    public float minYPosition = -4.35f;
    public float maxYPosition = 4.35f;
    public float minXPosition = -10f;

    private bool movingUp = true;

    private void Start()
    {
        // Set a random start movement direction
        movingUp = Random.Range(0, 2) == 0; // 50% chance of moving up, 50% chance of moving down
    }

    private void Update()
    {
        // Move the obstacle from right to left along the X-axis
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

        // Check if the obstacle's X position is beyond the minimum X position
        if (transform.position.x <= minXPosition)
        {
            // Destroy the obstacle GameObject
            Destroy(gameObject);
        }
    }
}
