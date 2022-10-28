using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [SerializeField] int _columnIndex = 0;
    BoxCollider2D _registratorCollider2D;

    public List<Bubble> columnArray = new List<Bubble>();
    public int columnFullness = 0;

    private void Start()
    {
        _registratorCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D bubble)
    {
        columnFullness++;
        columnArray.Add(bubble.GetComponent<Bubble>());
        columnArray[columnFullness - 1].inCollumn = _columnIndex;
    }

    public void BubblesDestroy()
    {
        foreach (Bubble bubble in columnArray)
        {
            if (bubble.inCollumn == _columnIndex && bubble.toDestroy == true)
            {
                bubble.DestroyBubble();
                columnFullness--;
            }
        }
        columnArray.RemoveAll(bubble => bubble.toDestroy == true);
    }

    public void SameBubbleChecker()
    {
        bool _isSame = false;

        if (columnFullness == 3)
        {
            foreach (Bubble bubble in columnArray)
            {
                if (bubble.type == columnArray[0].type)
                {
                    _isSame = true;
                }
                else
                {
                    _isSame = false;
                    break;
                }
            }
        }

        if (_isSame == true)
        {
            foreach (Bubble bubble in columnArray)
            {
                bubble.toDestroy = true;
            }
        }
    }
}