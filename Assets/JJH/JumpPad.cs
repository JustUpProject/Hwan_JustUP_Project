using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpPower = 10f; // ���� �� ����
    BasicControler player;

    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("�浹");
        if (other.CompareTag("Player")) // ĳ���Ϳ��� �浹 ����
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);
        }
    }
}