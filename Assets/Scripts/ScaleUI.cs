using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUI : MonoBehaviour {

    private const int defaultWidth = 1024;
    private const int defaultHeight = 600;
    public int deviceWidth;
    public int deviceHeight;
    public GameObject controls;
    public Rigidbody2D rb;
    public RectTransform rt;

	// Use this for initialization
	void Start () {

        controls = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody2D>();
        
       
	}
	
	// Update is called once per frame
	void Update () {
        ReSize();
	}

    void ReSize ()
    {
        /*
        int scaleWidth = deviceWidth / defaultWidth;
        int scaleHeight = deviceHeight / defaultHeight;
        Vector3 v3 = new Vector3(scaleWidth, scaleHeight, 1);

        //controls.gameObject.transform.localScale.Set(v3[0], v3[1], v3[2]);
        rt.localScale.Set(v3[0], v3[1], v3[2]);
        */
        Screen.SetResolution(1024, 600, true);
    }
}
