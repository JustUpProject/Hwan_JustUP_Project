using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class object_portal : MonoBehaviour
{
    public Transform otheportal; // �ٸ� ��Ż�� �����ϱ� ���� ����
    private static bool isTeleporting = false; // ���� ������ ����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTeleporting) // �÷��̾ ��Ż�� ������ �浹�ϰ� ���� �ڷ���Ʈ ���� �ƴ� ��
        {
            isTeleporting = true;
            Teleport(collision.transform);
        }
    }

    private void Teleport(Transform target)
    {
        // �÷��̾��� ������� Y ��ǥ�� ���
        float playerY = target.position.y - transform.position.y;

        target.position = new Vector3(otheportal.position.x, otheportal.position.y + playerY, otheportal.position.z);

        StartCoroutine(ResetTeleportFlag());
    }

    private System.Collections.IEnumerator ResetTeleportFlag()
    {
        yield return new WaitForSeconds(0.5f); // �ڷ���Ʈ �� ��� ��� (�ʿ信 ���� ����)
        isTeleporting = false;
    }
}