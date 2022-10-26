using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject _detacher;

    public Color _color;
    public int _type = 0;
    public int _score = 0;
    public int indexInCollumn;
    public bool toDestroy = false;
    bool _activeState = false;

    //ScoreBoard _scoreBoard;

    private void Awake()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                this._color = Color.red;
                this._score = 100;
                this._type = 1;
                return;
            case 2:
                this._color = Color.green;
                this._score = 200;
                this._type = 2;
                return;
            case 3:
                this._color = Color.blue;
                this._score = 300;
                this._type = 3;
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
    public void DestroyBubble()
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
