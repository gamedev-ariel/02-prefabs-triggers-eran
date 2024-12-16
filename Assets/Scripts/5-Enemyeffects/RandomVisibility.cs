using UnityEngine;

public class RandomVisibility : MonoBehaviour
{
    [Header("Visibility Settings")]
    [Tooltip("Minimum time the object remains visible.")]
    public float minVisibleTime = 1.0f;

    [Tooltip("Maximum time the object remains visible.")]
    public float maxVisibleTime = 5.0f;

    [Tooltip("Minimum time the object remains invisible.")]
    public float minInvisibleTime = 1.0f;

    [Tooltip("Maximum time the object remains invisible.")]
    public float maxInvisibleTime = 5.0f;

    // Reference to the Renderer component
    private Renderer objectRenderer;

    // Timer to keep track of visibility/invisibility duration
    private float timer;

    // Whether the object is currently visible
    private bool isVisible;

    void Start()
    {
        // Get the Renderer component
        objectRenderer = GetComponent<Renderer>();

        // Start with the object visible
        isVisible = true;
        objectRenderer.enabled = isVisible;

        // Set initial timer duration
        timer = GetRandomDuration(isVisible);
    }

    void Update()
    {
        // Decrease the timer by the time elapsed since last frame
        timer -= Time.deltaTime;

        // If the timer has expired, toggle visibility and reset the timer
        if (timer <= 0)
        {
            isVisible = !isVisible;
            objectRenderer.enabled = isVisible;
            timer = GetRandomDuration(isVisible);
        }
    }

    // Returns a random duration based on whether the object is visible or invisible
    private float GetRandomDuration(bool currentlyVisible)
    {
        if (currentlyVisible)
        {
            return Random.Range(minVisibleTime, maxVisibleTime);
        }
        else
        {
            return Random.Range(minInvisibleTime, maxInvisibleTime);
        }
    }
}
