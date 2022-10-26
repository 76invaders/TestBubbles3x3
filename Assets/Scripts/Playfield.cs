using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playfield : MonoBehaviour
{
    public Column[] Columns = new Column[3];

    private void FixedUpdate()
    {
        CheckAllCollumns();
    }

    public void CheckAllCollumns()
    {
        CheckVerticals();
        CheckHorisontals();
        CheckDiagonalFromZero();
        CheckDiagonalFromTwo();
        DestroyBubblesIntoAllColums();
    }

    public void CheckVerticals() //������������ ��������
    {
        foreach (Column column in Columns)
        {
            if (column.ColumnFullness == 3
                    && column.ColumnArray[0]._type != 0
                    && column.ColumnArray[0]._type == column.ColumnArray[1]._type
                    && column.ColumnArray[0]._type == column.ColumnArray[2]._type)
            {
                foreach (Bubble bubble in column.ColumnArray)
                {
                    bubble.toDestroy = true;
                }
            }
        }
    }

    public void CheckHorisontals() //�������������� ��������
    {
        for (int bubble = 0; bubble < 3; bubble++)
        {
            try
            {
                if (Columns[0].ColumnArray[bubble]._type == Columns[1].ColumnArray[bubble]._type &&
                    Columns[0].ColumnArray[bubble]._type == Columns[2].ColumnArray[bubble]._type)
                {
                    foreach (Column column in Columns)
                    {
                        column.ColumnArray[bubble].toDestroy = true;
                    }
                }
            }
            catch (NullReferenceException)
            {
            }
        }
    }

    public void CheckDiagonalFromZero() //������������ �������� �� 0 �� 2
    {
        try
        {
            if (Columns[0].ColumnArray[0]._type == Columns[1].ColumnArray[1]._type
                && Columns[0].ColumnArray[0]._type == Columns[2].ColumnArray[2]._type)
            {
                Columns[0].ColumnArray[0].toDestroy = true;
                Columns[1].ColumnArray[1].toDestroy = true;
                Columns[2].ColumnArray[2].toDestroy = true;
            }
        }
        catch (NullReferenceException)
        {
        }
    }

    public void CheckDiagonalFromTwo() //������������ �������� �� 2 �� 0
    {
        try
        {
            if (Columns[0].ColumnArray[2]._type == Columns[1].ColumnArray[1]._type
                && Columns[0].ColumnArray[2]._type == Columns[2].ColumnArray[0]._type)
            {
                Columns[0].ColumnArray[2].toDestroy = true;
                Columns[1].ColumnArray[1].toDestroy = true;
                Columns[2].ColumnArray[0].toDestroy = true;
            }
        }
        catch (NullReferenceException)
        {
        }
    }

    void DestroyBubblesIntoAllColums()
    {
        foreach(Column column in Columns)
        {
            column.ColumnFall();
        }
    }
    //�������� ��������
}