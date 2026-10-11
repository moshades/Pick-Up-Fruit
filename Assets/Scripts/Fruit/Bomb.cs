using UnityEngine;

public class Bomb : Fruit
{
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
        worldCanvas = GameObject.FindGameObjectWithTag("Effect").GetComponent<Canvas>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.gravityScale += 0.1f * Time.deltaTime;

        if (transform.position.y < deadZone)
        {
            Debug.Log("Bomb Deleted");
            Destroy(gameObject);
        }
    }
}
