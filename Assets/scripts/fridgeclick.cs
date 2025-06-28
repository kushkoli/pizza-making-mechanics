using UnityEngine;

public class FridgeClick : MonoBehaviour
{
    public FridgeToggle fridgeToggle;

    void OnMouseDown()
    {
        fridgeToggle.ToggleFridge();
    }
}
