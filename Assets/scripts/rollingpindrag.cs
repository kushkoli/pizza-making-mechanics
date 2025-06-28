using UnityEngine;

public class RollingPinDrag : MonoBehaviour
{
    private Vector2 startPos;
    private bool isDragging = false;
    private Rigidbody2D rb;
    private float returnSpeed = 5f; // Speed for snapping back

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // No gravity while on the table
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
                rb.linearVelocity = Vector2.zero; // Stop any movement before dragging
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
            StartCoroutine(SnapBack()); // Smooth return
        }
    }

    private System.Collections.IEnumerator SnapBack()
    {
        float elapsedTime = 0f;
        Vector2 currentPos = transform.position;

        while (elapsedTime < 1f)
        {
            transform.position = Vector2.Lerp(currentPos, startPos, elapsedTime);
            elapsedTime += Time.deltaTime * returnSpeed;
            yield return null;
        }

        transform.position = startPos;
    }
}
