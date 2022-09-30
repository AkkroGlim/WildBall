using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraSCr : MonoBehaviour
{
    private float yRotation;
    private float xRotation;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform pointPivot;
    private Quaternion lookRotation;
    private Quaternion pointPivotRotation;
    [SerializeField] private Transform cameraTransform;
    void Update()
    {        
        RotatePivot();        
    }

    public void LateUpdate()
    {
        Vector3 lookDirection = lookRotation * new Vector3(0, -0.5f, 1);
        Vector3 lookPosition = playerTransform.position - lookDirection * 3.6f;

        if (Physics.Raycast(playerTransform.position, -lookDirection, out RaycastHit hit, 3.6f))
        {
            lookPosition = playerTransform.position - lookDirection * hit.distance;
        }
        cameraTransform.SetPositionAndRotation(lookPosition, cameraTransform.rotation);
    }

    private void RotatePivot()
    {
        if (Time.timeScale > 0)
        {
            float yPivot = Input.GetAxis("Mouse X") * 600 * Time.fixedDeltaTime;
            float xPivot = Input.GetAxis("Mouse Y") * 600 * Time.fixedDeltaTime;
            
            yRotation += yPivot;
            xRotation -= xPivot;
            xRotation = Mathf.Clamp(xRotation, -30f, 30f);
            pointPivotRotation = Quaternion.Euler(0, yRotation, 0);
            lookRotation = Quaternion.Euler(xRotation, yRotation, 0);
            pointPivot.SetPositionAndRotation(Vector3.one, pointPivotRotation);
            transform.SetPositionAndRotation(Vector3.one, lookRotation);
        }
    }

    
}
