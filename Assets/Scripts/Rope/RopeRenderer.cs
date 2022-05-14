using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private int _segments = 10; 

    public void Draw(Vector3 startPoint, Vector3 endPoint, float length)
    {
        _lineRenderer.enabled = true;
        
        float interpolant = Vector3.Distance(startPoint, endPoint) / length;
        float offset = Mathf.Lerp(length / 2f, 0f, interpolant);

        Vector3 startDownPoint = startPoint + Vector3.down * offset;
        Vector3 endDownPoint = endPoint + Vector3.down * offset;

        _lineRenderer.positionCount = _segments + 1;
        for (int i = 0; i < _segments + 1; i++)
        {
            _lineRenderer.SetPosition(i, Bezier.GetPoint(startPoint, startDownPoint, endDownPoint, endPoint,
                (float)i / _segments));
        }
    }

    public void Hide()
    {
        _lineRenderer.enabled = false; 
    }
}