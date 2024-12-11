using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableOnRayTrigger : MonoBehaviour
{
    public XRRayInteractor leftRayInteractor; // Assign the Left-Hand XR Ray Interactor
    public XRRayInteractor rightRayInteractor; // Assign the Right-Hand XR Ray Interactor
    public AudioClip popSound; // Assign a pop sound in the Inspector

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component if not already present
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        CheckRayInteractors();
    }

    void CheckRayInteractors()
    {
        // Check if the left ray hits this object and the trigger is pressed
        if (IsRayInteractorHoveringAndTriggered(leftRayInteractor))
        {
            DisableObject();
            return;
        }

        // Check if the right ray hits this object and the trigger is pressed
        if (IsRayInteractorHoveringAndTriggered(rightRayInteractor))
        {
            DisableObject();
            return;
        }
    }

    bool IsRayInteractorHoveringAndTriggered(XRRayInteractor rayInteractor)
    {
        // Ensure the ray interactor is valid and check if it's hovering over this object
        if (rayInteractor != null && rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Check if the associated controller's trigger is pressed
                if (rayInteractor.TryGetComponent(out XRBaseController controller))
                {
                    return controller.activateInteractionState.activatedThisFrame;
                }
            }
        }

        return false;
    }

    void DisableObject()
    {
        // Play pop sound
        if (popSound != null)
        {
            AudioSource.PlayClipAtPoint(popSound, transform.position, 1.0f); // Play sound at full volume
            Debug.Log($"Playing sound: {popSound.name}");
        }
        else
        {
            Debug.LogWarning("Pop sound not assigned!");
        }

        // Notify ScoreManager to increment the score
        ScoreIncrementer.Instance?.AddScore(1);

        // Disable the object
        Debug.Log($"Object disabled: {gameObject.name}");
        gameObject.SetActive(false);
    }


}
