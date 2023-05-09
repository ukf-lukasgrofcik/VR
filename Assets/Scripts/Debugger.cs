using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugger : MonoBehaviour
{

    public static void Debug(string print)
    {
        if (singleton != null) singleton.Print(print);
    }

    private static Debugger singleton = null;
    public bool debug = false;
    public TMP_Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        singleton = this;
        Print("Debugger initialized");
    }
    
    public void Print(string print)
    {
        if (debug) text.SetText(print); 
    }
    
}
