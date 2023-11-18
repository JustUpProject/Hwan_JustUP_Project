using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_wind_sub : MonoBehaviour
{
    BasicControler player;
    float moveSpeed;
    Vector3 targetedPos;
    public bool canMoved = false;
    float scale;
    float count=0f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
        moveSpeed = player.moveSpeed;
        scale = transform.localScale.y/2;
        targetedPos = new Vector3(transform.position.x,transform.position.y+(scale),transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            canMoved = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(count < 50f) 
            {
                MoveToPosition(targetedPos);
                count = 0;
            }
            canMoved = false;
            count++;
        }
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        StartCoroutine(MoveToPositionCoroutine(targetPosition));
    }

    IEnumerator MoveToPositionCoroutine(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = player.transform.position;

        while (elapsedTime < 1f)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                yield break; // �ڷ�ƾ ����
            }

            player.transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed/scale;
            yield return null; // �� ������ ��ٸ�
        }

        // ������ �Ϸ�Ǹ� ���� ��ǥ ��ġ�� ���� (���� ��ġ�� ��Ȯ�ϰ� ���߱� ����)
        player.transform.position = targetPosition;
    }
}
