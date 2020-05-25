using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class de : MonoBehaviour
{
    public delegate void D1(int id);
    public event D1 DEvent;

    private void Start()
    {
        DEvent += new D1(f1);
        DEvent += new D1(f2);
        DEvent += new D1(f3);
        DEvent += new D1(f4);



        DEvent(10);
    }
    void f1(int id)
    {
        Debug.Log("1"); 
    }
    void f2(int id)
    {
        Debug.Log("2");
    }
    void f3(int id)
    {
        Debug.Log("3");
    }
    void f4(int id)
    {
        Debug.Log("4");
    }
}
