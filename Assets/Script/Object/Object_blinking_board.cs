using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_blinking_board : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private float timeInterval = 5f; //5�� �������� ��Ÿ���� �����
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        boxCollider = GetComponent<BoxCollider2D>(); 
        StartCoroutine(BoardObjectBlink());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator BoardObjectBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeInterval);

            // ������Ʈ�� Ȱ��ȭ ���¸� ������ŵ�ϴ�.
            spriteRenderer.enabled = !(spriteRenderer.enabled); // ������Ʈ ���� Ŵ
            boxCollider.enabled = !(boxCollider.enabled); //�ݶ��̴� ���� Ŵ
        }
    }
}
