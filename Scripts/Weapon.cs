using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;//旋转速度
    
    public float moveSpeed = 5f;//移动速度
    private Vector3 targetPos;//鼠标点击位置坐标
    public Transform playerTrans;//玩家坐标
    public ThrowCamaraController cameraController;//相机

    private bool isCallBack = false;//是否可以召回
    private bool isCauseFirstDamage; //是否可以造成第一次伤害
    private bool isCauseSecondDamage;//是否可以造成第二次伤害

    private bool isClickToThrowWeapon;
    private bool isClickToCallbackWeapon;

    //Effect
    public GameObject slashEffect;
    public GameObject weaponReturnEffect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCallBack)
        {
            targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 
                                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
            isClickToThrowWeapon = true;
        }
        if (Input.GetMouseButtonDown(0) && isCallBack)
        {
            isClickToCallbackWeapon = true;
        }

        if (isClickToThrowWeapon)
        {
            ThrowWeapon();
        }
        if (isClickToCallbackWeapon)
        {
            CallbackWeapon();
        }


        if (Vector2.Distance(transform.position, targetPos) <= 0.1f)
        {
            isClickToThrowWeapon = false;
            isCallBack = true;
            isCauseFirstDamage = false;
            
        }
        if (Vector2.Distance(transform.position, playerTrans.position) <= 0.1f)
        {
            isClickToCallbackWeapon = false;
            isCallBack = false;
            transform.SetParent(playerTrans);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            isCauseFirstDamage = false;
        }
    }

    private void SelfRotate()
    {
        transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
    }

    private void ThrowWeapon()
    {
        transform.SetParent(null);
        isCauseFirstDamage = true;
        SelfRotate();
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    private void CallbackWeapon()
    {
        isCauseFirstDamage = true;
        isCauseSecondDamage = true;
        SelfRotate();
        transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, moveSpeed * 5 * Time.deltaTime);

        if (Vector2.Distance(transform.position, playerTrans.position) <= 0.01f)
        {
            StartCoroutine(CallbackEffect());
            Instantiate(weaponReturnEffect, playerTrans.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemies") && isCauseFirstDamage)
        {
            other.GetComponentInChildren<HealthBar>().hp -= 25f;
            cameraController.isShake = true;
            cameraController.CameraShake(0.3f);
            isCauseSecondDamage = false;

            Instantiate(slashEffect, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemies") && isCauseSecondDamage)
        {
            other.GetComponentInChildren<HealthBar>().hp -= 25f;
            cameraController.isShake = true;
            cameraController.CameraShake(0.3f);

            Instantiate(slashEffect, transform.position, Quaternion.identity);
        }
        isCauseSecondDamage = true;
    }

    IEnumerator CallbackEffect()
    {
        cameraController.isShake = true;
        cameraController.CameraShake(0.3f);
        yield return new WaitForSeconds(0.4f);
        cameraController.isShake = false;
    }

}
