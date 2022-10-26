using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Column : MonoBehaviour
{
    Bubble[] ColumnArray = new Bubble[3];
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
        ColumnArray[0] = bubble.GetComponent<Bubble>();
    }
    //Перемещатор принятие если = 0 то переместить верхниенихе вайл
}
