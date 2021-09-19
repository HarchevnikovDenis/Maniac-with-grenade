using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryRenderer : MonoBehaviour
{
    [SerializeField] private int pointsInTrajectory;

    private LineRenderer lineRenderer;

    private Vector3[] points;
    private float time;

    private void Awake()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointsInTrajectory;

        points = new Vector3[pointsInTrajectory];
    }

    public void ShowTrajectory(Vector3 origin, Vector3 direction, float speed)
    {
        for (int i = 0; i < points.Length; i++)
        {
            time = i * 0.1f;
            points[i] = origin + direction * speed * time + (Physics.gravity * Mathf.Pow(time, 2) / 2.0f);

            if (points[i].y < 0.0f)
            {
                lineRenderer.positionCount = i + 1;
                break;
            }
        }

        lineRenderer.SetPositions(points);
    }

    public void HideTrajectory()
    {
        lineRenderer.positionCount = 0;
    }
}
