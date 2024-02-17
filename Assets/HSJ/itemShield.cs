using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using stateSheild;

namespace stateSheild
{
    public enum StatShield
    {
        ready,// ������ �����
        broken,// ������ �����
        unable // ������ ��볡
    }
}

public class itemShield : MonoBehaviour
{
    public StatShield shield;

    private SpriteRenderer effectPrefab;
    public bool UseItem = true;
    public float time;


    private void Update()
    {
        
        
    }

    void initShield()
    {
        shield = StatShield.ready;
        effectPrefab = BasicControler.Instance.transform.Find("Circle").gameObject.GetComponent<SpriteRenderer>();
        if (effectPrefab == null)
            Debug.Log("��ã��");
    }
    
    public void UseSkill()
    {
        initShield();
        Debug.Log("����1");

        StartCoroutine(Useing());
        
    }

    IEnumerator Useing()
    {
        effectPrefab.enabled = true;
        shield = StatShield.broken;
        yield return new WaitForSeconds(3.0f);
        
        if(UseItem == false)
        {
            yield return null;
        }

        effectPrefab.enabled = !(effectPrefab.enabled);
        shield = StatShield.unable;

        effectPrefab.enabled = false;
        shield = StatShield.ready;
        
        yield return null;
    }

    //switch (shield)
    //{

    //    case StatShield.ready:  //������ ����� �ʱ�ȭ�� ������ ���ð�� ���� ����

    //        init();

    //        timer = 3.0f;
    //        effectPrefab.enabled = true;
    //        Debug.Log(shield);
    //        shield = StatShield.broken;

    //        break;

    //    case StatShield.broken:  //������ ����� : ����� ��ȭ�� �°� ������ ����

    //        if (timer < 3.0f && timer >= 1.0f)
    //        {
    //            timer -= Time.deltaTime;
    //        }
    //        else if (timer < 1.0f && timer > 0f)
    //        {
    //            effectPrefab.enabled = !(effectPrefab.enabled);
    //            timer -= Time.deltaTime;
    //        }
    //        else
    //            shield = StatShield.unable;
    //        break;

    //    case StatShield.unable:  //������ ��볡 : ����� �ʿ��� �������� �ʱ�ȭ �� ����Ŭ�� ���ư�

    //        effectPrefab.enabled = false;
    //        shield = StatShield.ready;

    //        break;

    //    default:
    //        Debug.LogError("Unexpected value for smite enum: " + shield);
    //        break;
    //}
}