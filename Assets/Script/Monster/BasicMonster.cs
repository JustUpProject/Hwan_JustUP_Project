using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BasicMonster : MonoBehaviour
{
    BasicControler player;


    [System.Serializable]
    public enum MonsterType
    {
        AttackAble,
        ItemAttackAble,
        NotAttackAble
    }

    public MonsterType type;
    private bool direction = false; // true = ������ x++, false = ���� x--
    public float speedMonster;
    public float sizeMonster;  // Move�Լ����� ����� ���꿡 �� ���� ũ��

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<BasicControler>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.PlayerHealth);

        TurnMonster();
        MoveMonster();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (type == MonsterType.AttackAble)
            {
                if (player.transform.position.y > transform.position.y)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 3, 0);
                    Destroy(this.gameObject);
                    return;
                }
            }

            else if (type == MonsterType.ItemAttackAble)
            {

            }

            else if (type == MonsterType.NotAttackAble)
            {

            }

            player.PlayerHit();
        }
    }

    public void MoveMonster()
    {
        if(direction)
        {
            this.transform.position += new Vector3(speedMonster * Time.deltaTime, 0, 0);
        }
        if (!direction)
        {
            this.transform.position -= new Vector3(speedMonster * Time.deltaTime, 0, 0);
        }

    }

    private void Turn()
    {
        direction = !direction;
        Debug.Log("����");
    }

    private void TurnMonster()
    {
        Vector2 originR = transform.position + new Vector3(sizeMonster, 0, 0);
        Vector2 originL = transform.position - new Vector3(sizeMonster, 0, 0); ;
        Vector2 direction = Vector2.down;

        RaycastHit2D hitR = Physics2D.Raycast(originR, direction);
        RaycastHit2D hitL = Physics2D.Raycast(originL, direction);

        if (!hitR.collider.CompareTag("Floor") || !hitL.collider.CompareTag("Floor"))
        {
            Turn();
            Debug.Log("�ٴ� ����");

        }
    }
}
