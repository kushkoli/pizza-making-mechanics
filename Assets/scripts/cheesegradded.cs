using UnityEngine;

public class cheesegradded : MonoBehaviour
{
    public GameObject graddedcheeseprefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cheese"))
        {
            Vector2 spawnpoint = collision.transform.position;

            Destroy(collision.gameObject);

            Instantiate(graddedcheeseprefab,spawnpoint,Quaternion.identity);
        }
    }
}
