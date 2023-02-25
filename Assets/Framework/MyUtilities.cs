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
            Debug.Log("New Message at 11.51");
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

        public void MyMethod_Seven()
        {
            Debug.Log("Seven ");
        }

        public void MyMethod_Eight()
        {
            Debug.Log("Eight 8");
        }
    }
}
