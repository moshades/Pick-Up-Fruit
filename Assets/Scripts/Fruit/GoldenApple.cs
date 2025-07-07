using UnityEngine;

public class GoldenApple : Fruit
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        worldCanvas = GameObject.FindGameObjectWithTag("Effect").GetComponent<Canvas>();
        healthBar = GameObject.FindGameObjectWithTag("Health").GetComponent<HealthBar>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.gravityScale += 0.1f * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            Debug.Log("Golden Apple Deleted");
            Destroy(gameObject);
        }
    }
}
