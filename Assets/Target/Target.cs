using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 MousePos = Input.mousePosition;
        Vector3 ScreenPos = Camera.main.ScreenToWorldPoint(MousePos);

        transform.position = ScreenPos - Vector3.forward * ScreenPos.z;
    }
}
