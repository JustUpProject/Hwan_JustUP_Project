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

public class itemShield : Basic_Item
{
    public StatShield shield;

    private SpriteRenderer effectPrefab;

    public float timer;



    void init()
    {
        Debug.Log("ŬŬŬ");
        itemCode = 0;
        gameData = Resources.Load<GameData>("ScriptableObject/Datas");
        shield = stateSheild.StatShield.ready;
        effectPrefab = BasicControler.Instance.transform.Find("Circle").gameObject.GetComponent<SpriteRenderer>();
    }
    
    public override void UseSkill()
    {

        switch (shield)
        {
            
            case StatShield.ready:  //������ ����� �ʱ�ȭ�� ������ ���ð�� ���� ����

                init();
                
                timer = 3.0f;
                effectPrefab.enabled = true;
                Debug.Log(shield);
                shield = StatShield.broken;
                
                break;

            case StatShield.broken:  //������ ����� : ����� ��ȭ�� �°� ������ ����

                if (timer < 3.0f && timer >= 1.0f)
                {
                    timer -= Time.deltaTime;
                }
                else if (timer < 1.0f && timer > 0f)
                {
                    effectPrefab.enabled = !(effectPrefab.enabled);
                    timer -= Time.deltaTime;
                }
                else
                    shield = StatShield.unable;
                break;

            case StatShield.unable:  //������ ��볡 : ����� �ʿ��� �������� �ʱ�ȭ �� ����Ŭ�� ���ư�

                effectPrefab.enabled = false;
                shield = StatShield.ready;

                break;

            default:
                Debug.LogError("Unexpected value for smite enum: " + shield);
                break;
        }
    }
}