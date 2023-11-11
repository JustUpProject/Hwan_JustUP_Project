using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_fog : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float timeInterval = 3f; //3�� �������� ��Ÿ���� �����
    // Start is called before the first frame update
    void Start()
    {
        //������Ʈ ó���� ��Ȱ��ȭ
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FogObjectBlink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator FogObjectBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            // ������Ʈ�� Ȱ��ȭ ���¸� ������ŵ�ϴ�.
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            
        }
    }
}
