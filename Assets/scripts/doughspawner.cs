using UnityEngine;

public class DoughSpawner : MonoBehaviour
{
    public GameObject doughBallPrefab;
    private GameObject currentDough;
    private bool isDragging = false;
    private Rigidbody2D rb;

    void Update()
    {
        // Start dragging when clicking the dough bowl
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.gameObject == gameObject)
            {
                currentDough = Instantiate(doughBallPrefab, transform.position, Quaternion.identity);
                rb = currentDough.GetComponent<Rigidbody2D>();
                if (rb != null)
                    rb.gravityScale = 0f;

                isDragging = true;
            }
        }

        // Move the dough with the mouse while dragging
        if (isDragging && currentDough != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentDough.transform.position = mousePos;
        }

        // Drop the dough when mouse released
        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            isDragging = false;

            // Enable gravity on drop
            if (rb != null)
                rb.gravityScale = 1f;

            currentDough = null;
        }
    }
}
