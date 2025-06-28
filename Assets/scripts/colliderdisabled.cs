using UnityEngine;

public class DisableOvenOnCookedPizza : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Oven")) // ✅ Oven GameObject should have tag "Oven"
        {
            Collider2D ovenCollider = other.GetComponent<Collider2D>();
            if (ovenCollider != null)
            {
                ovenCollider.enabled = false;
                Debug.Log("🔥 Oven collider disabled by cooked pizza.");
            }
        }
    }
}
