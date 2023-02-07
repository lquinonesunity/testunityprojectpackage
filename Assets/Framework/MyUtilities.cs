using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLLTest {

    public class MyUtilities {
    
        public int c;

        public void AddValues(int a, int b) {
            c = a + b;  
        }
    
        public static int GenerateRandom(int min, int max) {
            System.Random rand = new System.Random();
            return rand.Next(min, max);
        }

        public void CallToShowText()
        {
            Class1.ShowText();
        }

        public void CallToShowText_Alternative()
        {
            Debug.Log("My Call 2");
            Class1.ShowText();
        }
        public void CallToNumbers()
        {
            Debug.Log("My Call Numbers 1");
            Class1.ShowNumber();
        }

        public void CallNewMethod()
        {
            Debug.Log("New Method");
            Class1.MyNewMethodShowSomething();
        }
    }
}
