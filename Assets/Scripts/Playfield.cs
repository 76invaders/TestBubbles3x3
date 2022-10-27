using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public static int ColumnsMaxValue = 3;
    public List<Column> Columns = new List<Column>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CheckVerticals();
            CheckHorisontal();
            DestroySelectedBubbles();
        }
    }

    public void CheckVerticals() //Вертикальная проверка
    {
        foreach (Column column in Columns)
        {
            column.SameBubbleChecker();
        }
    }

    public void CheckHorisontal() //Горизонтальная проверка
    {
        bool toDestroy = false;

        for (int bubbleRow = 0; bubbleRow < ColumnsMaxValue; bubbleRow++)
        {

            toDestroy = false;
            try
            {
                int buferBubble = Columns[0].ColumnArray[bubbleRow]._type;

                foreach (Column column in Columns)
                {
                    if (column.ColumnArray[bubbleRow]._type == buferBubble)
                    {
                        toDestroy = true;
                    }
                    else
                    {
                        toDestroy = false;
                        break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                continue;
            }

            if (toDestroy == true)
            {
                foreach (Column column in Columns)
                {
                    column.ColumnArray[bubbleRow].toDestroy = true;
                }
                Debug.Log("HorisontalIsTriggered");
            }
        }
    }

    private void DestroySelectedBubbles()
    {
        foreach (Column column in Columns)
        {
            column.BubblesDestroy();
        }
    }
    //проверка Геймовер
}