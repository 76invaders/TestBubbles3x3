using UnityEngine;

public class PendulumBubbleSpawner : MonoBehaviour
{
    [SerializeField] GameObject _bubble;

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
        Instantiate(_bubble, this.transform, false);
    }
}