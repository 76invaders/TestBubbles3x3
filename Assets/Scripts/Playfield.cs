using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public static int ColumnsMaxValue = 3;
    public List<Column> Columns = new List<Column>();
    public PendulumBubbleSpawner _spawner;

    private void Start()
    {
        _spawner = GameObject.Find("ShotPoint").GetComponent<PendulumBubbleSpawner>();
    }

    public void CheckAndDelAllBubbles()
    {
        CheckVerticals();
        CheckHorisontal();
        CheckDiagonalFromZero();
        CheckDiagonalFromTop();
        DestroySelectedBubbles();
        _spawner.SpawnBubble();
    }

    private void DestroySelectedBubbles()
    {
        foreach (Column column in Columns)
        {
            column.BubblesDestroy();
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
            try//Убрать, заменить на высоту
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
            }
        }
    }
    public void CheckDiagonalFromZero() //Диагональная проверка с нуля
    {
        bool toDestroy = false;

        for (int counter = 0; counter < Columns.Count-1; counter++)
        {
            if (Columns[counter].ColumnFullness >= 1 + counter &&
                Columns[counter + 1].ColumnFullness >= 2 + counter &&
                Columns[counter + 1].ColumnArray[counter + 1]._type == Columns[counter].ColumnArray[counter]._type)
            {
                toDestroy = true;
            }
            else
            {
                toDestroy = false;
                break;
            }
        }

        if (toDestroy == true)
        {
            int counter = 0;
            foreach (Column column in Columns)
            {
                Columns[counter].ColumnArray[counter].toDestroy = true;
                counter++;
            }
        }
    }

    public void CheckDiagonalFromTop() //Диагональная проверка с топа
    {
        bool toDestroy = false;

        for (int counter = 0; counter < Columns.Count - 1; counter++)
        {
            if (Columns[counter].ColumnFullness >= 3 - counter &&
                Columns[counter + 1].ColumnFullness >= 2 - counter &&
                Columns[counter + 1].ColumnArray[1 - counter]._type == Columns[counter].ColumnArray[2 - counter]._type)
            {
                toDestroy = true;
            }
            else
            {
                toDestroy = false;
                break;
            }
        }

        if (toDestroy == true)
        {
            int counter = 0;
            foreach (Column column in Columns)
            {
                Columns[counter].ColumnArray[2 - counter].toDestroy = true;
                counter++;
            }
        }
    }
    //проверка Геймовер
}