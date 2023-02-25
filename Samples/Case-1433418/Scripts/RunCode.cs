using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLLTest;

public class RunCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var myInstance = new MyUtilities();
        
        //Class 1
        myInstance.TooManyMethods();
        Debug.Log("Just one method");
    }
}
