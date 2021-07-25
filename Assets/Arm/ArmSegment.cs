using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSegment : MonoBehaviour
{
    public Transform FrontJoint;
    public Transform BackJoint;

    public Vector3 Anchor(Vector3 target, bool reverse = false)
    {
        Transform DraggingJoint = BackJoint;
        Transform DraggedJoint = FrontJoint;

        if(reverse)
        {
            DraggingJoint = FrontJoint;
            DraggedJoint = BackJoint;
        }

        Vector3 direction = (DraggedJoint.position - DraggingJoint.position).normalized;
        Vector3 directionTarget = (DraggedJoint.position - target).normalized;

        float Angle = Vector2.SignedAngle(direction, directionTarget);

        transform.RotateAround(DraggedJoint.position, Vector3.forward, Angle);
        transform.position += target - DraggingJoint.position;

        return DraggedJoint.position;
    }
}
