using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HighlightBubble : MonoBehaviour
{
    public Material highlightMaterial; // Assign the highlight material
    public Material defaultMaterial; // Assign the default material

    public XRRayInteractor leftRayInteractor; // Assign the Left-Hand XR Ray Interactor
    public XRRayInteractor rightRayInteractor; // Assign the Right-Hand XR Ray Interactor

    private Renderer bubbleRenderer;
    private bool isHighlighted = false;

    void Start()
    {
        // Cache the Renderer
        bubbleRenderer = GetComponent<Renderer>();
        if (bubbleRenderer == null)
        {
            Debug.LogError("Renderer not found on the bubble!");
        }
    }

    void Update()
    {
        CheckRayInteractors();
    }

    void CheckRayInteractors()
    {
        // Check if the left ray hits this bubble
        if (leftRayInteractor != null && leftRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit leftHit))
        {
            if (leftHit.collider != null && leftHit.collider.gameObject == gameObject)
            {
                HighlightBubbleEffect();
                return; // Prevent overwriting with right ray logic
            }
        }

        // Check if the right ray hits this bubble
        if (rightRayInteractor != null && rightRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit rightHit))
        {
            if (rightHit.collider != null && rightHit.collider.gameObject == gameObject)
            {
                HighlightBubbleEffect();
                return; // Highlight handled, exit
            }
        }

        // If neither ray is hitting, remove the highlight
        RemoveHighlight();
    }

    void HighlightBubbleEffect()
    {
        if (!isHighlighted && highlightMaterial != null && bubbleRenderer != null)
        {
            bubbleRenderer.material = highlightMaterial;
            isHighlighted = true;
            Debug.Log("Bubble highlighted: " + gameObject.name);
        }
    }

    void RemoveHighlight()
    {
        if (isHighlighted && defaultMaterial != null && bubbleRenderer != null)
        {
            bubbleRenderer.material = defaultMaterial;
            isHighlighted = false;
            Debug.Log("Highlight removed: " + gameObject.name);
        }
    }
}
