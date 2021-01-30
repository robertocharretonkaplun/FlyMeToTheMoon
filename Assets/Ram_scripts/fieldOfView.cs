using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldOfView : MonoBehaviour
{
    public float g_viewRadius;
    [Range(0,360)]
    public float g_viewAngle;
    public LayerMask g_targetMask;
    public LayerMask g_obstacleMask;

    [HideInInspector]
    public List<Transform> g_visibleTargets = new List<Transform>();

    void Start()
    {
        StartCoroutine("findTargetsWithDelay", 0.2f);
    }

    IEnumerator findTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            findVisibleTargets();
        }
    }

    void findVisibleTargets()
    {
        g_visibleTargets.Clear();

        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, g_viewRadius, g_targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - target.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < g_viewAngle * 0.5)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!(Physics.Raycast(transform.position, dirToTarget, dstToTarget, g_obstacleMask)))
                {
                    g_visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 dirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!(angleIsGlobal))
        {
            angleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
