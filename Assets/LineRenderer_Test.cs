using System.Linq;
using UnityEngine;

public class LineRenderer_Test : MonoBehaviour
{
    [SerializeField] Transform[] Ts;
    [SerializeField] LineRenderer lineRenderer;

    private void Update()
    {
        lineRenderer.SetPositions(Ts.Select(t => t.position).ToArray());
    }
}
