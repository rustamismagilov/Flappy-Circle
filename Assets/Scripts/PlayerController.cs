using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 3f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Apply an upward force for jumping
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
