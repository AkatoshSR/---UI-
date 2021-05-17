using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float cameraMoveMinX;
    [SerializeField] private float cameraMoveMaxX;
    [SerializeField] private float cameraMoveMinY;
    [SerializeField] private float cameraMoveMaxY;

    //temp
    private Vector3 temp2;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void LateUpdate()
    {
        
        temp2.Set(Mathf.Clamp(target.position.x,cameraMoveMinX,cameraMoveMaxX), Mathf.Clamp(target.position.y,cameraMoveMinY,cameraMoveMaxY), transform.position.z);
        transform.position = Vector3.Lerp(transform.position, temp2,smoothSpeed * Time.deltaTime);

    }

}
