using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumAppearance : MonoBehaviour
{
    SceneLoader _sceneLoader;
    Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _sceneLoader = gameObject.GetComponent<SceneLoader>();
    }

    void Start()
    {
        StartCoroutine("LaunchPendulumCorutine");
    }

    IEnumerator LaunchPendulumCorutine()
    {
        LaunchPendulum();
        yield return new WaitForSeconds(3f);
        _sceneLoader.ChangeScene(1);
        StopAllCoroutines();
    }

    void LaunchPendulum()
    {
        _rigidbody.AddForce(new Vector2(0,120f));
    }
}
