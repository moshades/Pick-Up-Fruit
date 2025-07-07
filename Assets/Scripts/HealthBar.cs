using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int health = 3;
    public List<GameObject> hearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(Transform child in transform)
        {
            hearts.Add(child.gameObject);
        }
    }

    public void KillLive(int liveToKill)
    {
        hearts[health - 1].SetActive(false);
        health -= liveToKill;
    }
}
