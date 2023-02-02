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
        myInstance.AddValues(5,7);
        Debug.Log(myInstance.c);
        
        myInstance.CallToShowText();
        
        myInstance.CallToShowText_Alternative();

    }
}
