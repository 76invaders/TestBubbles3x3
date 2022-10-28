using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playfield : MonoBehaviour
{
    [SerializeField] int _columnsMaxValue = 3;
    [SerializeField] List<Column> _columns = new List<Column>();

    [SerializeField] public PendulumBubbleSpawner spawner;

    private void Start()
    {
        spawner = GameObject.Find("ShotPoint").GetComponent<PendulumBubbleSpawner>();
    }

    public IEnumerator CheckAndDelAllBubblesCorutine()
    {
        for (int count = _columnsMaxValue; count > 0; count--)
        {
            CheckVerticals();
            CheckHorisontal();
            CheckDiagonalFromZero();
            CheckDiagonalFromTop();
            DestroySelectedBubbles();
            GameOverCheck();
            yield return new WaitForSeconds(0.5f);
        }
        spawner.SpawnBubble();
        StopAllCoroutines();
    }

    void DestroySelectedBubbles()
    {
        foreach (Column column in _columns)
        {
            column.BubblesDestroy();
        }
    }

    void CheckVerticals() //Вертикальная проверка
    {
        foreach (Column column in _columns)
        {
            column.SameBubbleChecker();
        }
    }

    void CheckHorisontal() //Горизонтальная проверка
    {
        bool _toDestroy = false;

        for (int bubbleRow = 0; bubbleRow < _columnsMaxValue; bubbleRow++)
        {

            _toDestroy = false;
            try
            {
                int buferBubble = _columns[0].columnArray[bubbleRow].type;

                foreach (Column column in _columns)
                {
                    if (column.columnArray[bubbleRow].type == buferBubble)
                    {
                        _toDestroy = true;
                    }
                    else
                    {
                        _toDestroy = false;
                        break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                continue;
            }

            if (_toDestroy == true)
            {
                foreach (Column column in _columns)
                {
                    column.columnArray[bubbleRow].toDestroy = true;
                }
            }
        }
    }

    void CheckDiagonalFromZero() //Диагональная проверка с нуля
    {
        bool _toDestroy = false;

        for (int counter = 0; counter < _columns.Count - 1; counter++)
        {
            if (_columns[counter].columnFullness >= 1 + counter &&
                _columns[counter + 1].columnFullness >= 2 + counter &&
                _columns[counter + 1].columnArray[counter + 1].type == _columns[counter].columnArray[counter].type)
            {
                _toDestroy = true;
            }
            else
            {
                _toDestroy = false;
                break;
            }
        }

        if (_toDestroy == true)
        {
            int _counter = 0;
            foreach (Column column in _columns)
            {
                _columns[_counter].columnArray[_counter].toDestroy = true;
                _counter++;
            }
        }
    }

    void CheckDiagonalFromTop() //Диагональная проверка с топа
    {
        bool _toDestroy = false;

        for (int counter = 0; counter < _columns.Count - 1; counter++)
        {
            if (_columns[counter].columnFullness >= 3 - counter &&
                _columns[counter + 1].columnFullness >= 2 - counter &&
                _columns[counter + 1].columnArray[1 - counter].type == _columns[counter].columnArray[2 - counter].type)
            {
                _toDestroy = true;
            }
            else
            {
                _toDestroy = false;
                break;
            }
        }

        if (_toDestroy == true)
        {
            int _counter = 0;
            foreach (Column column in _columns)
            {
                _columns[_counter].columnArray[2 - _counter].toDestroy = true;
                _counter++;
            }
        }
    }

    void GameOverCheck()
    {
        int _counter = 0;
        foreach (Column column in _columns)
        {
            if (column.columnFullness >= _columnsMaxValue)
            {
                _counter++;
            }
            else
            {
                break;
            }
        }

        if(_counter == _columns.Count)
        {
            SceneManager.LoadScene(2);
        }
    }
}