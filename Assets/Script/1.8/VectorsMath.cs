using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorsMath : MonoBehaviour
{
    [SerializeField] Transform V1;
    [SerializeField] Transform V2;

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        DrawGizmosLine(transform, V1);

        Gizmos.color = Color.blue;
        DrawGizmosLine(transform, V2);

        //Sum

        Gizmos.color = Color.green;
        DrawGizmosLine(transform, V1.position + V2.position);

        //dif

        Gizmos.color = Color.magenta;
        DrawGizmosLine(transform, V1.position - V2.position);
        DrawGizmosLine(transform, V2.position - V1.position);

        //multiply

        Gizmos.color = Color.cyan;
        Vector3 cross = Vector3.Cross(V1.position.normalized, V2.position.normalized);
        DrawGizmosLine(transform, cross);

        //distance

        Debug.Log("Расстояние до V1" + Vector3.Distance(transform.position, V1.position));
        Debug.Log("Расстояние до V2" + Vector3.Distance(transform.position, V2.position));
    }
    private void DrawGizmosLine(Transform startPosition, Transform endPosition)
    {
        Gizmos.DrawLine(startPosition.position, endPosition.position);
    }   
    private void DrawGizmosLine(Transform startPosition, Vector3 endPosition)
    {
        Gizmos.DrawLine(startPosition.position, endPosition);
    }
}
