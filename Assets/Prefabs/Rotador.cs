using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Rotador : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(40, 50, 70) * Time.deltaTime);
    }
}