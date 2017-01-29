using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPosition : MonoBehaviour {

    // Update is called once per frame
    void Update()
    {
        Vector3 ScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 CursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ScreenPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(CursorPos);
    }
}
