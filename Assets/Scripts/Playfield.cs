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
            CheckDiagonalFromZero();
            DestroySelectedBubbles();
        }
    }

    public void CheckVerticals() //������������ ��������
    {
        foreach (Column column in Columns)
        {
            column.SameBubbleChecker();
        }
    }

    public void CheckHorisontal() //�������������� ��������
    {
        bool toDestroy = false;

        for (int bubbleRow = 0; bubbleRow < ColumnsMaxValue; bubbleRow++)
        {

            toDestroy = false;
            try//������, �������� �� ������
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
    public void CheckDiagonalFromZero() //������������ �������� � ����
    {
        bool toDestroy = false;

        for (int counter = 0; counter < Columns.Count-1; counter++)
        {
            if (Columns[counter].ColumnFullness >= 1 + counter &&
                Columns[counter + 1].ColumnFullness >= 2 + counter &&
                Columns[counter + 1].ColumnArray[counter + 1]._type == Columns[counter].ColumnArray[counter]._type)
                {
                    toDestroy = true;
                    Debug.Log("��������� ������� ���");
                }
            else
            {
                toDestroy = false;
                Debug.Log("��������� �����������");
                break;
            }
        }

        if (toDestroy == true)
        {
            int counter = 0;
            foreach (Column column in Columns)
            {
                Columns[counter].ColumnArray[counter].toDestroy = true;
                Debug.Log("��������� ��������");
                counter++;
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
    //�������� ��������
}