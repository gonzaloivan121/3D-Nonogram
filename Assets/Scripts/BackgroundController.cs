using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        var height = 2.0f * Mathf.Tan(0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad) * 37.15f;
        var width = height * Screen.width / Screen.height;

        transform.localScale = new Vector3(width, height);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
