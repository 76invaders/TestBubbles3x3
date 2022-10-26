using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Bubble[] ColumnArray = new Bubble[3];
    BoxCollider2D registratorCollider2D;
    public int ColumnFullness = 0;
    public int ColumnIndex = 0;

    private void Start()
    {
        registratorCollider2D = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D bubble)
    {
        ColumnArray[ColumnFullness] = bubble.GetComponent<Bubble>();
        ColumnArray[ColumnFullness].indexInCollumn = ColumnFullness;
        ColumnFullness++;
    }

    public void ColumnFall()
    {
        for (int bubblePosition = 0; bubblePosition < 3; bubblePosition++)
        {
            try
            {
                if (ColumnArray[bubblePosition].toDestroy == true)
                {
                    for (int counter = bubblePosition; counter < 3; counter++)
                    {
                        if (counter == 2)
                        {
                            ColumnArray[counter] = GetComponent<Bubble>();
                        }
                        else
                        {
                            ColumnArray[counter] = ColumnArray[counter + 1];
                        }
                    }
                    ColumnFullness--;
                }
            }
            catch (NullReferenceException)
            {
            }
        }
        BubblesDestroy();
    }

    public void BubblesDestroy()
    {
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        {
            foreach (GameObject bubble in bubbles)
            {
                Bubble bubbleScript = bubble.GetComponent<Bubble>();
                if (bubbleScript.toDestroy == true)
                {
                    bubbleScript.toDestroy = false;
                    bubbleScript.DestroyBubble();
                }
            }
        }
    }

    public void ArrayCheker()
    {
        foreach (Bubble bubble in ColumnArray)
        {
            Debug.Log(bubble.toDestroy);
        }
    }
}
