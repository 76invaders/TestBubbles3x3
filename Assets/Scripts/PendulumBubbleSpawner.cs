using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumBubbleSpawner : MonoBehaviour
{
    public GameObject bubble;

    void Start()
    {
        SpawnBubble();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            SpawnBubble();
        }
    }
    public void SpawnBubble()
    {
        Instantiate(bubble, this.transform, false);
    }
}
