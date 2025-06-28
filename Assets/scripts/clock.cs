using UnityEngine;

public class clock : MonoBehaviour
{
    
    public Sprite[] clocks;               // Add sprites in order: 12, 3, 6, 9
    public float frametime = 1f;
    public ovenss ovenRef;
    public GameObject cookedpizza;
    public Transform spawnpoint;
    // 👈 Drag your oven script here in Inspector

    private SpriteRenderer sr;

    void Start()
    {
        
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = clocks[0];            // Start at 12
    }

    public void startclock()
    {
        Debug.Log("⏱️ startclock() was called!");
        StartCoroutine(runclockonce());
    }

    private System.Collections.IEnumerator runclockonce()
    {
        for (int i = 1; i < clocks.Length; i++)
        {
            yield return new WaitForSeconds(frametime);
            sr.sprite = clocks[i];
        }

        yield return new WaitForSeconds(frametime);
        sr.sprite = clocks[0];            // Back to 12

        // 🔔 Oven opens again after timer finishes
        if (ovenRef != null)
        {
            ovenRef.SetState(true);    
            
            Debug.Log("✅ Clock finished. Oven reopened.");
        }
        if (cookedpizza != null)
        {
            Vector2 pos = spawnpoint.position;
            Instantiate(cookedpizza, pos,Quaternion.identity);
            
        }
    }
}
