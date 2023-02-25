using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLLTest {
    public class MyUtilities {
        public void MyMethod_One()
        {
            Debug.Log("MyMethod_One(): ");
            Class1.ShowTextFromResources();
        }
        public void MyMethod_Two()
        {
            Debug.Log("MyMethod_Two(): ");
            Class2.ShowAMessage();
        }

        public void MyMethod_Three()
        {
            Debug.Log("MyM 3: ");
            Class1.ShowTextFromResources();
            Class2.ShowAMessage();
            Debug.Log("Method 3");
            Debug.Log("Method 33");
            Debug.Log("Method 666");
            
            Debug.Log("New message");
        }

        public void MyMethodFour()
        {
            Debug.Log("Look at: ");
            Debug.Log("My Log");
            Class2.ShowAMessage();
        }

        public void MyMethod_Five()
        {
            Debug.Log("Five ");
        }

        public void MyMethod_S()
        {
            Debug.Log("S ");
        }
    }
}
