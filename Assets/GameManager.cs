using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public  class GameManager : MonoBehaviour
{
    public   GameObject[] Bases;
    
    // Start is called before the first frame update
    public  void  Start()
    {
        Bases = new GameObject[4];
        for (int i = 0; i < Bases.Length; i++)
        {
            Bases = GameObject.FindGameObjectsWithTag("Base"); 
        }
        

    }

    // Update is called once per frame
    public  void Update()
    {
        Debug.Log(Bases.Length);
    }
}
