using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] BubblesParticles _bubblesParticles;
    Playfield _playfield;
    ScoreBoard _scoreBoard;

    public int type = 0;
    public int inCollumn = -1;
    public bool toDestroy = false;

    Color _color;
    int _score = 0;
    bool _activeState = false;

    private void Awake()
    {
        switch (Random.Range(1, 4))
        {
            case 1:
                this._color = Color.red;
                this._score = 100;
                this.type = 1;
                return;
            case 2:
                this._color = Color.green;
                this._score = 200;
                this.type = 2;
                return;
            case 3:
                this._color = Color.blue;
                this._score = 300;
                this.type = 3;
                return;
        }
    }

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = _color;
        _playfield = GameObject.FindGameObjectWithTag("Playfield").GetComponent<Playfield>();
        _scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<ScoreBoard>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine("BubbleLaunchCorutine");
            enabled = false;
        }
    }

    public void DestroyBubble()
    {
        _scoreBoard.RecivePoints(_score);
        Destroy(gameObject,0.5f);
        _bubblesParticles.CreateParticle(_color, transform);
    }

    IEnumerator BubbleLaunchCorutine()
    {
        LaunchBubble();
        yield return new WaitForSeconds(3.0f);
        IsAutoDestroy();
    }

    public void LaunchBubble()
    {
        if (_activeState == false && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _activeState = true;
            this.transform.SetParent(GameObject.FindGameObjectWithTag("Detacher").transform);
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    public void IsAutoDestroy()
    {
        if (inCollumn == -1)
        {
            StopCoroutine("BubbleLaunchCorutine");
            _playfield.spawner.SpawnBubble();
            Destroy(gameObject);
        }
        else
        {
            StopCoroutine("BubbleLaunchCorutine");
            _bubblesParticles.CreateParticle(_color, transform);
            _playfield.StartCoroutine("CheckAndDelAllBubblesCorutine");
        }
    }
}