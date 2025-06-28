using UnityEngine;

public class FridgeToggle : MonoBehaviour
{
    public GameObject fridgeClosed;
    public GameObject fridgeOpen;
    public GameObject[] foodItems;

    private bool isOpen = false;

    void Start()
    {
        UpdateFridgeState(false);
    }

    public void ToggleFridge()
    {
        isOpen = !isOpen;
        UpdateFridgeState(isOpen);
    }

    private void UpdateFridgeState(bool open)
    {
        fridgeClosed.SetActive(!open);
        fridgeOpen.SetActive(open);

        foreach (GameObject item in foodItems)
        {
            if (item != null)
                item.SetActive(open);
        }
    }

    public bool IsOpen()
    {
        return isOpen;
    }
}
