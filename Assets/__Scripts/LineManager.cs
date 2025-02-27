using UnityEngine;
using System.Collections.Generic;

public class LineManager : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>();

    void Start()
    {
        lineRenderer.positionCount = 0;
    }

    public void AddPoint(Vector3 point)
    {
        if (!points.Contains(point))
        {
            points.Add(point);
            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPositions(points.ToArray());
        }
    }
}
