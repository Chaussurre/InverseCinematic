using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSegment : MonoBehaviour
{
    public Transform frontJoint;
    public Transform BackJoint;

    public void Anchor(Vector3 target, bool reverse = false)
    {
        transform.position += target - BackJoint.position;
    }
}
