using System;
using UnityEngine;

public class PaintingsDB : MonoBehaviour
{
    public bool[] completed;
    public bool[] selected;


    private void Start()
    {
        completed = new  bool[8];
        selected = new  bool[8];
    }
    
}
