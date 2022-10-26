using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject _detacher;

    Color _color;
    public int _score = 0;

    //ScoreBoard _scoreBoard;
    bool _activeState = false;

    private void Awake()
    {
        switch (Random.Range(0, 3))
        {
            case 0:
                this._color = Color.red;
                this._score = 100;
                return;
            case 1:
                this._color = Color.green;
                this._score = 200;
                return;
            case 2:
                this._color = Color.blue;
                this._score = 300;
                return;
        }
    }

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = _color;
    }

    private void Update()
    {
        BubbleLauncher();
    }
    public void BubbleDestroyer()
    { 
        Destroy(gameObject);
        //+Очки
    }

    //Скорборд(int a) Для расширения функционала и декомпозиции

    public void BubbleLauncher()
    {
        if (_activeState == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _activeState = true;
            this.transform.SetParent(GameObject.FindGameObjectWithTag("Detacher").transform);
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }

    }
}
