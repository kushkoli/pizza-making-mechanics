using UnityEngine;

public class ovenss : MonoBehaviour
{
    public string triggerTag = "Pizza";      // Tag your raw pizza with this
    public GameObject ovenOpen;              // Assign open visual
    public GameObject ovenWorking;           // Assign working visual
    public clock clockRef;                   // Drag your clock script here in Inspector

    private void Start()
    {
        SetState(true);                      // Start with oven open
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag(triggerTag))
            return;

        rawpizzadraganddrop drag = other.GetComponent<rawpizzadraganddrop>();
        if (drag != null && drag.isDragging)
            return;

        SetState(false);                     // Close the oven
        Debug.Log("🔥 Oven closed and baking!");

        if (clockRef != null)
            clockRef.startclock();           // Start clock animation

        Destroy(other.gameObject);           // Remove raw pizza
    }

    public void SetState(bool open)
    {
        ovenOpen.SetActive(open);            // Show open visual
        ovenWorking.SetActive(!open);        // Show working visual
    }
}
