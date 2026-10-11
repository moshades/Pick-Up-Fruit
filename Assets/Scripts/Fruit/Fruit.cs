using TMPro;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public float deadZone = -5;
    public float spawnChance;
    public float spawnRate;
    public int point;
    public int live;

    public LogicManager logic;
    public Rigidbody2D rb;
    public GameObject popUpTxt;
    public Canvas worldCanvas;
    public HealthBar healthBar;
}