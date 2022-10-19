using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionDeTorreta : MonoBehaviour
{
    public Transform Objetivo;
   
    void Update()
    {
        Vector3 ObjetivoOrientation=Objetivo.position - transform.position;
        Debug.DrawRay(transform.position, ObjetivoOrientation, Color.blue);

        Quaternion ObjetivoOrietationQuaternion = Quaternion.LookRotation(ObjetivoOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, ObjetivoOrietationQuaternion, Time.deltaTime);
    }
}
