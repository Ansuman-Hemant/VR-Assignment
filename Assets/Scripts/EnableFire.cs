using UnityEngine;

public class EnableFire : MonoBehaviour
{
    public GameObject FireParent; // The parent GameObject containing all the wood GameObjects

    public void Enablefire()
    {
        if (FireParent != null)
        {
            // Loop through all child GameObjects under the parent
            foreach (Transform fire in FireParent.transform)
            {
                fire.gameObject.SetActive(true); // Enable each wood
            }
        }
        else
        {
            Debug.LogWarning("Fire parent GameObject is not assigned.");
        }
    }
}
