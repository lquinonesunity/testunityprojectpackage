using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace DLLTest
{
    public class Class1 : MonoBehaviour
    {
        public static void ShowText()
        {
            var mytext = Resources.Load<TextAsset>("Text/MyText");
            Debug.Log(mytext.text);
        }
        public static void ShowNumber()
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.Log("N: " + i);
            }
        }
        
        public static void MyNewMethodShowSomething()
        {
            Debug.Log("MyNewMethodShowSomething(): Something");
        }
    }
}
