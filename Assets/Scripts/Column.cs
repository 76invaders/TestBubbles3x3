using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Column : MonoBehaviour
{
    public List<Bubble> ColumnArray = new List<Bubble>();
    BoxCollider2D registratorCollider2D;
    public int ColumnFullness = 0;
    public int ColumnIndex = 0;

    private void Start()
    {
        registratorCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D bubble)
    {
        ColumnFullness++;
        ColumnArray.Add(bubble.GetComponent<Bubble>());
        ColumnArray[ColumnFullness-1].InCollumn = ColumnIndex;
    }

    public void BubblesDestroy()
    {
        foreach (Bubble bubble in ColumnArray)
        {
            if (bubble.InCollumn == ColumnIndex && bubble.toDestroy == true)
            {
                bubble.DestroyBubble();
                ColumnFullness--;
            }
        }
        ColumnArray.RemoveAll(b => b.toDestroy == true);
    }

    public void SameBubbleChecker()
    {
        bool isSame = false;

        if (ColumnFullness == 3)
        {
            foreach (Bubble bubble in ColumnArray)
            {
                if (bubble._type == ColumnArray[0]._type)
                {
                    isSame = true;
                }
                else
                {
                    isSame = false;
                    break;
                }
            }
        }

        if (isSame == true)
        {
            foreach (Bubble bubble in ColumnArray)
            {
                bubble.toDestroy = true;
            }
        }
    }
}
