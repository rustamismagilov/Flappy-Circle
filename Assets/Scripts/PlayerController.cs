using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 3f;
    private Rigidbody2D rb;

    // Flag that indicates whether the game is currently paused
    private bool paused;

    // Reference to the pause screen object in the scene
    public GameObject pauseScreen;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Check if the user has pressed the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //then call CheckForPause method
            CheckForPause();
        }

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Apply an upward force for jumping
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Check for pause input
    void CheckForPause()
    {
        if (!paused)
        {
            // if game paused then show the "paused" screen and freeze the game with Time.timeScale = 0;
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            // if game unpaused then hide the "paused" screen and unfreeze the game with Time.timeScale = 1;
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
