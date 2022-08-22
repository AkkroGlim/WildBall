using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSCr : MonoBehaviour
{
    private float yRotation;
    [SerializeField] private Transform playerTransform;
    private Quaternion lookRotation;
    [SerializeField] private Transform cameraTransform;
    void Update()
    {
        RotatePivot();
    }

    public void LateUpdate()
    {
        Vector3 lookDirection = lookRotation *  new Vector3(0, -0.5f ,1);
        Vector3 lookPosition = playerTransform.position - lookDirection * 3.6f;

        if (Physics.Raycast(playerTransform.position, -lookDirection, out RaycastHit hit, 3.6f))
        {
            lookPosition = playerTransform.position - lookDirection * hit.distance;
        }
        cameraTransform.SetPositionAndRotation(lookPosition, cameraTransform.rotation);       
    }

    private void RotatePivot()
    {
        if(Time.timeScale > 0)
        {
            float yPivot = Input.GetAxis("Mouse X") * 600 * Time.fixedDeltaTime;
            yRotation += yPivot;
            lookRotation = Quaternion.Euler(0, yRotation, 0);
            transform.SetPositionAndRotation(Vector3.one, lookRotation);
        }
    }
}
