using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPower = 10f; // ���� �� ����
    BasicControler player;

    private void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ĳ���Ϳ��� �浹 ����
        {
            BasicControler.Instance.GetComponent<Rigidbody2D>().velocity = new Vector3(0,jumpPower,0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            BasicControler.Instance.SetDir();
            if(BasicControler.Instance.getPrivateDir() == true)
            {
                player.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            else
            {
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

}