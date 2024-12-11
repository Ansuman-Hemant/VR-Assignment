using UnityEngine;

public class PointArrowAtTarget : MonoBehaviour
{
    public Transform target; // Assign the target object in the Inspector

    void Update()
    {
        if (target != null)
        {
            // Calculate the direction to the target
            Vector3 direction = target.position - transform.position;

            // Update the arrow's rotation to face the target
            transform.rotation = Quaternion.LookRotation(direction);

            // Correct for the fact that the Quad faces forward in 2D (Z-axis)
            transform.Rotate(90, 0, 0); // Adjust as needed based on the arrow's orientation
        }
    }
}
