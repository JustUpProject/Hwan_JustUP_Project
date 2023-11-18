using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.UI.Image;

public class object_ice : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    BasicControler player;

    float originSlide;
    float changedSlide;
    bool checkPlayer;
    float moveSpeedPlayer;
    float changedMoveSpeed;

    public bool isWall = true; //wall���·� ��ġ�ҷ��� trueüũǥ�� �ƴҽ� falseüũ����
    public bool dir=false; //false = L��ġ true =R��ġ
    public float rayLength;
    // Start is called before the first frame update
    void Start()
    {
        player =    FindObjectOfType<BasicControler>();
        originSlide = player.slidingSpeed;
        changedSlide = 1.0f;
        moveSpeedPlayer = player.moveSpeed;
        changedMoveSpeed = player.moveSpeed + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWall)
        {
            if (dir)
            {
                checkPlayer = PlayerCheckLeft();
                if (checkPlayer)
                    player.slidingSpeed = changedSlide;
                else
                    player.slidingSpeed = originSlide;
            }
            else
            {
                checkPlayer = PlayerCheckRight();
                if (checkPlayer)
                    player.slidingSpeed = changedSlide;
                else
                    player.slidingSpeed = originSlide;
            }
        }
        else 
        {
            checkPlayer = PlayerCheckVertical();
            if (checkPlayer)
            {
                player.moveSpeed = changedMoveSpeed;
            }
            else
            {
                player.moveSpeed = moveSpeedPlayer;
            }
        }      
    }
    private bool PlayerCheckRight()
    {
        Vector2 origin = this.transform.position;
        Vector2 size = this.transform.localScale;

        Vector2 direction = Vector2.right;
        RaycastHit2D hits = Physics2D.BoxCast(origin, size, 0, direction, rayLength, playerMask);
        if (hits.collider != null)
        {
            if (hits.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private bool PlayerCheckLeft()
    {
        Vector2 origin = this.transform.position;
        Vector2 size = this.transform.localScale;

        Vector2 direction = Vector2.left;
        RaycastHit2D hits = Physics2D.BoxCast(origin, size, 0, direction, rayLength, playerMask);
        if (hits.collider != null)
        {
            if (hits.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }

    private bool PlayerCheckVertical()
    {
        Vector2 origin = this.transform.position;

        Vector2 direction = Vector2.up;
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction, rayLength, playerMask);

        foreach (RaycastHit2D hit in hits)
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        return false;
    }
}
