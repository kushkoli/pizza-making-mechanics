using UnityEngine;
using UnityEngine.InputSystem;

public class cheesespawner : MonoBehaviour
{
    public GameObject slicedcheeseprefab;
    private GameObject currentcheese;
    private bool isdragging;
    private Rigidbody2D rb;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousepos);

            if (hit != null && hit.gameObject == gameObject)
            {
                currentcheese = Instantiate(slicedcheeseprefab, transform.position, Quaternion.identity);
                rb = currentcheese.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.gravityScale = 0f;

                }
                isdragging = true;

            }
        }
        if (isdragging && currentcheese != null) 
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentcheese.transform.position = mousepos;

        }
        if (Input.GetMouseButtonUp(0)) 
        {
            isdragging = false;
            if(rb != null) 
            {
                rb.gravityScale = 1f;

               
            }
            currentcheese = null;
        }
    }

}
