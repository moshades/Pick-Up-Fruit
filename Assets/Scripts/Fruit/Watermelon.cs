using UnityEngine;

public class Watermelon : Fruit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        worldCanvas = GameObject.FindGameObjectWithTag("Effect").GetComponent<Canvas>();
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.gravityScale += 0.1f * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            healthBar.KillLive(live);
            Debug.Log("Watermelon Deleted");
            Destroy(gameObject);
        }
    }
}

