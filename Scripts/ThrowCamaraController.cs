using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCamaraController : MonoBehaviour
{
    public Transform playerTrans;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveMinX;
    [SerializeField] private float moveMaxX;
    [SerializeField] private float moveMinY;
    [SerializeField] private float moveMaxY;

    private Vector3 cameraShake;
    private float shakeAmount;
    public bool isShake;

    //temp
    Vector3 temp_moveDir;

    private void Update()
    {
        temp_moveDir.Set(Mathf.Clamp(Mathf.Lerp(transform.position.x, playerTrans.position.x, moveSpeed * Time.deltaTime), moveMinX, moveMaxX), 
                        Mathf.Clamp(Mathf.Lerp(transform.position.y, playerTrans.position.y, moveSpeed * Time.deltaTime), moveMinY, moveMaxY),
                        transform.position.z);
        transform.position = temp_moveDir;

        if (shakeAmount > 0)
        {
            cameraShake = new Vector3(Random.Range(-shakeAmount, shakeAmount), Random.Range(-shakeAmount, shakeAmount), 0);
            shakeAmount -= Time.deltaTime;
        }
        else
        {
            cameraShake = Vector3.zero;
        }

        if (isShake)
        {
            transform.position += cameraShake;
        }

    }

    public void CameraShake(float _shakeAmount)
    {
        shakeAmount = _shakeAmount;
    }

}
