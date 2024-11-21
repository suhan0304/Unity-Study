using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test {

    public class nullableTest {
        string st = null;
    }
    

    public class Test : MonoBehaviour
    {

        private void Start() {
            StartCoroutine(MyCoroutine()); 
        }


        IEnumerator MyCoroutine() {
            int n = 10;
            Debug.Log(n);

            yield return new WaitForSeconds(1);

            Debug.Log(n);
        }
    }
}