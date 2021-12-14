using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
 
public class DataMask : MonoBehaviour {
 
    public InputField input;
 
    int prevLength;
 
    void Start () {
        input.onValueChanged.AddListener (OnValueChanged);
    }
 
    public void OnValueChanged (string str) {
        print ("String:" + str);
        if (str.Length > 0) {
            input.onValueChanged.RemoveAllListeners ();
            if (!char.IsDigit (str[str.Length - 1]) && str[str.Length - 1] != '/') { // Remove Letters
                input.text = str.Remove (str.Length - 1);
                input.caretPosition = input.text.Length;
            } else if (str.Length == 2 || str.Length == 5) {
                if (str.Length < prevLength) { // Delete
                    input.text = str.Remove (str.Length - 1);
                    input.caretPosition = input.text.Length;
                } else { // Add
                    input.text = str + "/";
                    input.caretPosition = input.text.Length;
                }
            }
            input.onValueChanged.AddListener (OnValueChanged);
        }
        prevLength = input.text.Length;
    }
}