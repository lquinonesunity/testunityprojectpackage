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
        public static void ShowTextFromResources()
        {
            var mytext = Resources.Load<TextAsset>("Text/MyText");
            Debug.Log(mytext.text);
        }
    }
}
