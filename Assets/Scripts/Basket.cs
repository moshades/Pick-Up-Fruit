using System.Drawing;
using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public Rigidbody2D basketRigidbody;
    public AudioSource bombSFX;
    public LogicManager logic;
    public Camera mainCam;

    private float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float halfHeight = mainCam.orthographicSize;
        float halfWidth = halfHeight * mainCam.aspect;

        float halfBasket = GetComponent<SpriteRenderer>().bounds.extents.x;

        minX = mainCam.transform.position.x - halfWidth + halfBasket;
        maxX = mainCam.transform.position.x + halfWidth - halfBasket;
    }

    private void OnMouseDrag()
    {
        if (!logic.isGameOver)
        {
            // Convert mouse's screen position to mouse's world position
            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = Mathf.Abs(mainCam.transform.position.z - transform.position.z);
            Vector3 mouseWorldPos = mainCam.ScreenToWorldPoint(mouseScreenPos);

            float clampedX = Mathf.Clamp(mouseWorldPos.x, minX, maxX);
            Vector2 targetPos = new Vector2(clampedX, transform.position.y);
            basketRigidbody.MovePosition(targetPos);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            var script = collision.GetComponent<Fruit>();
            Instantiate(script.popUpTxt, transform.position, Quaternion.identity, script.worldCanvas.transform)
                .GetComponentInChildren<TextMeshProUGUI>().text = "+" + script.point;
            logic.AddScore(script.point);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bomb"))
        {
            bombSFX.Play();
            logic.GameOver();
            Destroy(collision.gameObject);
        }
    }
}
