using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public List<Column> Columns = new List<Column>();
    public int ColumnsMaxValue = 3;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            CheckVerticals();
            CheckHorisontals();
            CheckDiagonalFromZero();
            CheckDiagonalFromTop();
        }
    }

    public void CheckVerticals() //Вертикальная проверка
    {
        bool _isToDestroy = false;

        foreach (Column column in Columns)
        {
            _isToDestroy = false;

            if (column.ColumnFullness == ColumnsMaxValue)
            {
                for (int count = 1; count < Columns.Count; count++)
                {

                    if ((column.ColumnArray[count]._type) == (column.ColumnArray[count - 1]._type))
                    {
                        _isToDestroy = true;
                    }
                    else
                    {
                        _isToDestroy = false;
                        break;
                    }
                }
            }
            if (_isToDestroy == true)
            {
                foreach (Bubble bubble in column.ColumnArray)
                {
                    bubble.toDestroy = true;
                }
            }
        }
    }

    public void CheckHorisontals() //Горизонтальная проверка
    {
        bool _isToDestroy = false;

        for (int bubbleCount = 0; bubbleCount < ColumnsMaxValue; bubbleCount++)
        {
            _isToDestroy = false;
            Debug.Log(Columns.Count);
            for (int ColumnCount = 1; ColumnCount < Columns.Count; ColumnCount++)
            {
                Debug.Log(ColumnCount);
                Debug.Log(Columns.Count);
                try
                {
                    if (Columns[ColumnCount].ColumnArray[bubbleCount]._type
                        == (Columns[ColumnCount - 1].ColumnArray[bubbleCount])._type)
                    {
                        _isToDestroy = true;
                    }
                    else
                    {
                        _isToDestroy = false;
                        break;
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    _isToDestroy = false;
                    break;
                }
            }

            if (_isToDestroy == true)
            {
                foreach (Column column in Columns)
                {
                    column.ColumnArray[bubbleCount].toDestroy = true;
                }
            }
        }
    }

    public void CheckDiagonalFromZero() //Диагональная проверка с нуля
    {
        bool _isToDestroy = false;

        for (int ColumnCount = 1; ColumnCount < Columns.Count; ColumnCount++)
        {
            _isToDestroy = false;
            try
            {
                if (Columns[ColumnCount].ColumnArray[ColumnCount]._type
                == (Columns[ColumnCount - 1].ColumnArray[ColumnCount- 1])._type)
                {
                    _isToDestroy = true;
                }
                else
                {
                    _isToDestroy = false;
                    break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                _isToDestroy = false;
                break;
            }

            if (_isToDestroy == true)
            {
                int count = 0;
                foreach (Column column in Columns)
                {
                    Columns[count].ColumnArray[count].toDestroy = true;
                    count++;
                }
            }
        }
    }

    public void CheckDiagonalFromTop() //Диагональная проверка с максимума
    {
        bool _isToDestroy = false;

        for (int ColumnCount = Columns.Count-1; ColumnCount >= 0; ColumnCount--)
        {
            _isToDestroy = false;
            try
            {
                if (Columns[ColumnCount].ColumnArray[ColumnCount]._type
                == (Columns[ColumnCount - 1].ColumnArray[ColumnCount - 1])._type)
                {
                    _isToDestroy = true;
                }
                else
                {
                    _isToDestroy = false;
                    break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                _isToDestroy = false;
                break;
            }

            Debug.Log(_isToDestroy);

            if (_isToDestroy == true)
            {
                int countBubble = Columns.Count - 1;
                int countColumn = 0;
                foreach (Column column in Columns)
                {
                    Columns[countColumn].ColumnArray[countBubble].toDestroy = true;
                    countBubble--;
                    countColumn++;
                }
            }
        }
    }


    void DestroyBubblesIntoAllColums()
    {
        foreach (Column column in Columns)
        {
            
        }
    }
        //проверка Геймовер
}