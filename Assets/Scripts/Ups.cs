using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ups : MonoBehaviour
{
    public InputField inputField;
    public void Awake ()
   {
     inputField = GetComponent<InputField>();
     inputField.onValueChanged.AddListener( delegate { Manage(); } );
   }
   public void Manage ()
   {
     inputField.text = inputField.text.ToUpper();
     Debug.Log( "Test" );
   }
}
