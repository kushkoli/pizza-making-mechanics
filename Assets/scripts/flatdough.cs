using UnityEngine;

public class flatdough : MonoBehaviour
{
    public GameObject flatdoughprefab;
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
        if (collision.CompareTag("dough"))
        {
            Vector2 spawnposition = collision.transform.position;

            Destroy(collision.gameObject);

            Instantiate(flatdoughprefab, spawnposition, Quaternion.identity);

        }
    }
}
