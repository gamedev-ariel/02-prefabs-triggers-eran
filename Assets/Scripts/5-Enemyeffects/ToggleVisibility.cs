//using UnityEngine;
//using UnityEngine.InputSystem;

//public class ToggleVisibility : MonoBehaviour
//{
//    [Header("Input Action Settings")]
//    [Tooltip("The input action used to toggle visibility.")]
//    public InputAction toggleAction;

//    [Header("Visibility Settings")]
//    [Tooltip("The duration in seconds for which the object will remain invisible.")]
//    public float invisibleDuration = 3.0f; // זמן ברירת מחדל של invisibility

//    private Renderer objectRenderer;
//    private float timer;
//    private bool isInvisible;

//    void Awake()
//    {
//        // Get the Renderer component
//        objectRenderer = GetComponent<Renderer>();

//        // Enable the input action
//        toggleAction.Enable();
//    }

//    void OnDestroy()
//    {
//        // Disable the input action when the object is destroyed
//        toggleAction.Disable();
//    }

//    void Update()
//    {
//        // Check if the toggle action was triggered
//        if (toggleAction.WasPressedThisFrame() && !isInvisible)
//        {
//            // Start the invisibility timer
//            isInvisible = true;
//            objectRenderer.enabled = false;
//            timer = invisibleDuration;
//        }

//        // If the object is currently invisible, decrease the timer
//        if (isInvisible)
//        {
//            timer -= Time.deltaTime;
//            if (timer <= 0)
//            {
//                // Reset visibility when the timer expires
//                isInvisible = false;
//                objectRenderer.enabled = true;
//            }
//        }
//    }
//}



using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleVisibility : MonoBehaviour
{
    [Header("Input Action Settings")]
    [Tooltip("The input action used to toggle visibility.")]
    public InputAction toggleAction;

    [Header("Visibility Settings")]
    [Tooltip("The duration in seconds for which the object will remain invisible.")]
    public float invisibleDuration = 3.0f; // זמן ברירת מחדל של invisibility

    private Renderer objectRenderer;
    private Collider objectCollider;
    private float timer;
    private bool isInvisible;

    void Awake()
    {
        // Get the Renderer and Collider components
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider>();

        // Enable the input action
        toggleAction.Enable();
    }

    void OnDestroy()
    {
        // Disable the input action when the object is destroyed
        toggleAction.Disable();
    }

    void Update()
    {
        // Check if the toggle action was triggered
        if (toggleAction.WasPressedThisFrame() && !isInvisible)
        {
            // Start the invisibility timer
            isInvisible = true;
            objectRenderer.enabled = false;
            if (objectCollider != null)
            {
                objectCollider.enabled = false; // Disable the collider
            }
            timer = invisibleDuration;
        }

        // If the object is currently invisible, decrease the timer
        if (isInvisible)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // Reset visibility and collider when the timer expires
                isInvisible = false;
                objectRenderer.enabled = true;
                if (objectCollider != null)
                {
                    objectCollider.enabled = true; // Enable the collider
                }
            }
        }
    }
}

