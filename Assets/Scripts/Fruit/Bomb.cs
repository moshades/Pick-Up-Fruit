using UnityEngine;

public class Bomb : Fruit
{
    public AudioSource bombSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Basket"))
        {
            bombSFX.Play();
            logic.GameOver();
            Destroy(gameObject);
        }
    }
}
