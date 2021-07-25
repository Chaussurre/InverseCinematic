using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField]
    ArmSegment SegmentPrefab;

    Target Target;

    [SerializeField, Range(0, 10)]
    int NbSegment;

    readonly List<ArmSegment> segments = new List<ArmSegment>();

    private void Start()
    {
        Target = FindObjectOfType<Target>();
    }

    private void OnEnable()
    {
        Vector3 target = transform.position;
        for(int i = 0; i < NbSegment; i++)
        {
            ArmSegment segment = Instantiate(SegmentPrefab, transform);
            target = segment.Anchor(target);
            segments.Add(segment);
        }
    }

    private void Update()
    {
        Vector3 TargetPoint = Target.transform.position;

        for (int i = 0; i < segments.Count; i++)
            TargetPoint = segments[i].Anchor(TargetPoint, true);

        TargetPoint = transform.position;
        for (int i = segments.Count - 1; i >= 0; i--)
            TargetPoint = segments[i].Anchor(TargetPoint);
    }
}
