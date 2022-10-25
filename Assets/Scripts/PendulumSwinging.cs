using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumSwinging : MonoBehaviour
{
    public float _angle = 40f;
    public float _speed = 1f;

    void FixedUpdate()
    {
        MakeASwing(_angle, _speed);
    }

    void MakeASwing(float angle, float speed)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Sin(Time.realtimeSinceStartup * speed));
    }
}
