using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckResolution : MonoBehaviour
{
   private void Awake()
   {
      Debug.Log(Screen.width + "   " + Screen.height);
   }

   private void Start()
   {
      Debug.Log(Screen.width + "   " + Screen.height);
   }

 
}
