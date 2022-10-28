using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpawnPendulum : MonoBehaviour
{
    [SerializeField] GameObject _pendulum;

    public void PendulumSpawn()
    {
        Instantiate(_pendulum, new Vector3(0,-4,0), transform.rotation);
    }
}
