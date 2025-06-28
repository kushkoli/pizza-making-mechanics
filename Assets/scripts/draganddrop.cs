using UnityEngine;

public class draganddrop : MonoBehaviour
{
    private bool isdragging = false;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousepos);

            if (hit != null && hit.gameObject == gameObject) 
            {
                isdragging = true;
                rb.linearVelocity = Vector2.zero;                
            }
        }
        if (Input.GetMouseButton(0) && isdragging)
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousepos;
        }
        if (Input.GetMouseButtonUp(0) && isdragging) 
        {
            isdragging = false;
            rb.gravityScale = 1f;
        }
    }
}
