using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScore : MonoBehaviour {

    private TextMesh text;
    private float Timer;
	// Use this for initialization
	void Start () {
        text = GetComponent<TextMesh>();
        Timer = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Timer += Time.deltaTime;
        text.text = Timer.ToString();
	}
}
