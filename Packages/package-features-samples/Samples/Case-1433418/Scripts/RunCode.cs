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
        myInstance.MyMethod_One();
        
        //Class 2
        myInstance.MyMethod_Two();
        
        // new method
        myInstance.MyMethod_Three();
        
        // justo a try
        Debug.Log("Just a try");
        
        // 4th method
        myInstance.MyMethodFour();
        
        // 5th method
        myInstance.MyMethod_Five();
        
        // 6th method
        myInstance.MyMethod_S();
        
        // 7th method
        myInstance.MyMethod_Seven();
        
        // 8th method
        myInstance.MyMethod_Eight();
        
        // 9th method
        myInstance.MyMethod_Nine();
    }
}
