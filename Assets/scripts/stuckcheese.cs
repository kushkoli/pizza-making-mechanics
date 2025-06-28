using UnityEngine;

public class stuckcheese : MonoBehaviour
{
    private bool hasmerged = false;
    public GameObject pizzawithcheese;
    private Rigidbody2D rb;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (hasmerged)
            return;

        if (other.CompareTag("flat base"))
        {
            GameObject rawpizza = Instantiate(pizzawithcheese, transform.position, Quaternion.identity);

            rb = rawpizza.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 1f;
                rb.bodyType = RigidbodyType2D.Dynamic;
            }

            Destroy(gameObject);        // Destroy grated cheese
            Destroy(other.gameObject);  // Destroy flat base

            hasmerged = true;
        }
    }
}
