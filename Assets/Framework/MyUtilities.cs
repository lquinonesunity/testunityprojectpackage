using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLLTest {
    public class MyUtilities {
        public void TooManyMethods()
        {
            Debug.Log("MyMethod_One(): ");
            Class1.ShowTextFromResources();
        }
        public void TooManyMethods_2()
        {
            Debug.Log("MyMethod_One(): ");
            Class1.ShowTextFromResources();
            Class2.ShowAMessage();
        }
    }
}
