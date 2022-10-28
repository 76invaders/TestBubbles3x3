using UnityEngine;

public class PendulumSwinging : MonoBehaviour
{
    [SerializeField] float _angle = 40f;
    [SerializeField] int _speed = 3;

    void Update()
    {
        MakeASwing(_angle);
    }

    void MakeASwing(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Sin(Time.realtimeSinceStartup * _speed));
    }
}