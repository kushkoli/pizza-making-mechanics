using UnityEngine;

public class graddedcheese : MonoBehaviour
{
    private Vector2 startpos;
    private bool isdraging = false;
    Rigidbody2D rb;
    private float returnspeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D hit = Physics2D.OverlapPoint(mousepos);

            if(hit != null && hit.gameObject == gameObject)
            {
                isdraging = true;
                rb.linearVelocity = Vector2.zero;
            }
        }
        if (Input.GetMouseButton(0)&& isdraging) 
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = mousepos;
        }
        if (Input.GetMouseButtonUp(0) && isdraging) 
        {
            isdraging = false;
            StartCoroutine(SnapBack());
        }
    }
    private System.Collections.IEnumerator SnapBack()
    {
        float elapsedtime = 0f;
        Vector2 currentposition = transform.position;

        while (elapsedtime < 1f)
        {
            transform.position=Vector2.Lerp(currentposition,startpos,elapsedtime);
            elapsedtime += Time.deltaTime * returnspeed;
            yield return null;

        }
        transform.position = startpos;

    }

}
