using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof (fieldOfView))]
public class fieldOfViewEditor : Editor
{
    void onSceneGUI()
    {
        fieldOfView fow = (fieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.g_viewRadius);

        Vector3 viewAngleA = fow.dirFromAngle(-fow.g_viewAngle * 0.5f, false);
        Vector3 viewAngleB = fow.dirFromAngle(fow.g_viewAngle * 0.5f, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.g_viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.g_viewRadius);

        Handles.color = Color.red;
        foreach (Transform visibleTargets in fow.g_visibleTargets)
        {
            Handles.DrawLine(fow.transform.position, visibleTargets.position);
        }
    }
}
