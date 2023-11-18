using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class object_portal : MonoBehaviour
{
    BasicControler player;
    public GameObject otherPortal; // �ٸ� ��Ż
    public Transform portalPoint; // ��Ż�� ���� �̵��� ��ġ
    public float teleportCooldown = 0f;

    bool teleportable = false;


    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
        teleportCooldown += Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) // �÷��̾ ��Ż�� �����ϸ�
        {
            if (teleportCooldown >= 1f)
            {
                teleportable = true;
                Teleport(collision.collider.gameObject); // �÷��̾ �̵���Ŵ                                               

            }

        }

    }

    private void Teleport(GameObject objectToTeleport)
    {
        if (teleportable)
        {
            objectToTeleport.transform.position = portalPoint.position;
            // �ٸ� ��Ż�� portalPoint�� �̵���Ŵ
            teleportCooldown = 0f;
            teleportable = false;
        }

    }

}