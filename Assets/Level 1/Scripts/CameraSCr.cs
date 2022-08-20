using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSCr : MonoBehaviour
{
    private float yRotation;

    void Update()
    {
        RotatePivot();
    }

    private void RotatePivot()
    {
        if(Time.timeScale > 0)
        {
            float yPivot = Input.GetAxis("Mouse X") * 600 * Time.fixedDeltaTime;
            yRotation += yPivot;
            gameObject.transform.localEulerAngles = new Vector3(0f, yRotation, 0f);
        }        
    }
}
