using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class PaintingInteractionBrush : MonoBehaviour
{
    public Camera VRCamera; // Assign the XR camera (not needed if using the ray interactor)
    public RenderTexture paintTexture; // The Render Texture for the canvas
    public float brushSize = 0.1f; // Size of the brush strokes

    public XRRayInteractor rightRayInteractor; // Reference to the right XR Ray Interactor
    public InputActionProperty triggerAction; // Trigger action for input

    private GameObject currentBrush;
    private Renderer brushRenderer;
    private AudioSource audioSource;

    void Start()
    {
        // Cache the Renderer and AudioSource
        brushRenderer = GetComponent<Renderer>();
        if (brushRenderer == null)
        {
            Debug.LogError("Renderer not found on the brush!");
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        // Check if trigger is pressed and paint if true
        if (IsTriggerPressed())
        {
            Vector3 brushPosition = GetBrushPosition();

            if (brushPosition != Vector3.zero)
            {
                Paint(brushPosition);
            }
        }
    }

    Vector3 GetBrushPosition()
    {
        // Raycast from the right ray interactor
        if (rightRayInteractor != null && rightRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Canvas")) // Ensure only the canvas is painted
            {
                return hit.point; // Return the point where the ray hits the canvas
            }
        }
        return Vector3.zero;
    }

    void Paint(Vector3 position)
    {
        // Instantiate the brush at the paint position if not already present
        if (currentBrush == null)
        {
            currentBrush = Instantiate(gameObject, position, Quaternion.identity); // Duplicate brush at position
        }
        currentBrush.transform.position = position; // Move brush to paint position

        // Optionally add sound effect or visual feedback here
        PlayPopSound();
    }

    bool IsTriggerPressed()
    {
        // Check if the trigger is pressed via InputAction
        return triggerAction.action.ReadValue<float>() > 0.5f; // Trigger is pressed
    }

    void PlayPopSound()
    {
        // Play a pop sound (if assigned)
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
