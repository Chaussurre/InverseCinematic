using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField]
    ArmSegment SegmentPrefab;

    [SerializeField, Range(0, 10)]
    int NbSegment;

    readonly List<ArmSegment> segments = new List<ArmSegment>();

    private void OnEnable()
    {
        for(int i = 0; i < NbSegment; i++)
        {
            Vector3 target = transform.position;

            if (segments.Count > 0)
                target = segments[segments.Count - 1].frontJoint.position;

            ArmSegment segment = Instantiate(SegmentPrefab, transform);
            segment.Anchor(target);
            segments.Add(segment);
        }
    }
}
