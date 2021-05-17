using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthPoint;
    public Image HealthSlow;
    [SerializeField] private float speed;

    public float hp;
    public float maxHp = 120f;

    private void Start()
    {
        hp = maxHp;
    }

    private void Update()
    {
        HealthPoint.fillAmount = hp / maxHp;

        if (HealthSlow.fillAmount > HealthPoint.fillAmount)
        {
            HealthSlow.fillAmount -= speed * Time.deltaTime;
        }
        else
        {
            HealthSlow.fillAmount = HealthPoint.fillAmount;
        }
    }

}
