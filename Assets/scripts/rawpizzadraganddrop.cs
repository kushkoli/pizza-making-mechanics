using UnityEngine;

public class rawpizzadraganddrop : MonoBehaviour
{
    public bool isDragging = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Keep gravity as set in Inspector (don’t override)
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == gameObject)
            {
                isDragging = true;
                rb.linearVelocity = Vector2.zero;       // ✅ correct property for Rigidbody2D
                rb.gravityScale = 0f;             // Pause falling while dragging
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;
            rb.gravityScale = 1f;                 // Resume falling
        }
    }
}
