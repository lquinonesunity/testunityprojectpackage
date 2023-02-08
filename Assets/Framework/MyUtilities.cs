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
    }
}
