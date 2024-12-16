using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [Header("Oscillation Settings")]
    [Tooltip("The speed of oscillation (higher value = faster movement).")]
    public float speed = 1.0f;

    [Tooltip("Amplitude of oscillation for each axis (X, Y, Z).")]
    public Vector3 amplitude = new Vector3(1.0f, 0.0f, 0.0f);

    // Keeps track of the oscillation progress
    private float timeCounter;

    // Update is called once per frame
    void Update()
    {
        // Increment the time counter based on speed
        timeCounter += Time.deltaTime * speed;

        // Calculate the oscillation offset using sine functions
        Vector3 offset = new Vector3(
            Mathf.Sin(timeCounter) * amplitude.x, // Oscillation on the X-axis
            Mathf.Sin(timeCounter) * amplitude.y, // Oscillation on the Y-axis
            Mathf.Sin(timeCounter) * amplitude.z  // Oscillation on the Z-axis
        );

        // Add the oscillation offset to the current position
        transform.position += offset * Time.deltaTime;
    }
}
