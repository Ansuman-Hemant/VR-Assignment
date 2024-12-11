using UnityEngine;

public class EnableWood : MonoBehaviour
{
    public GameObject WoodsParent; // The parent GameObject containing all the wood GameObjects

    public void EnableWoods()
    {
        if (WoodsParent != null)
        {
            // Loop through all child GameObjects under the parent
            foreach (Transform wood in WoodsParent.transform)
            {
                wood.gameObject.SetActive(true); // Enable each wood
            }
        }
        else
        {
            Debug.LogWarning("Woods parent GameObject is not assigned.");
        }
    }
}
