using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasicControler : MonoBehaviour
{
    [SerializeField] private LayerMask floorMask;
    [SerializeField] private LayerMask wallMask;
    SlidingPartical partical;

    private bool direction = false; //true = ���������� �̵�, false = �������� �̵�
    private bool firstJumpAble = true; //�÷��̾��� ���� ���� ���� üũ
    private bool doubleJumpAble = true; //�÷��̾��� ���� ���� ���� ���� üũ
    private bool isSlidingOnWall = false; //�÷��̾ ���� ����ִ��� ���� üũ

    public float rayLength;
    public float rayLengthFloor;
    public float moveSpeed;
    public float jumpPower;
    public float slidingSpeed; //�����̵����� �������� �ӵ�

    private int playerHealth;
    public int PlayerHealth
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    Vector3 wallPos; //�浹�� ���� ��ġ ����


    void Start()
    {
        playerHealth = 3;
        partical = GetComponent<SlidingPartical>();
    }


    void Update()
    {

        WallCheck();  
        FloorCheck();
        JumpPlayer();


        if (isSlidingOnWall == true && FloorCheck() == false)
        {
            return;
        }

        MovePlayer();
    }

    

    private void MovePlayer()
    {
        if (direction == true)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            
        }
        else if (direction == false)
        {
            transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
            
        }
    }

    private void JumpPlayer()
    {
        if ((Input.GetKeyDown(KeyCode.Space)) && doubleJumpAble == true)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            isSlidingOnWall = false;
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpPower, 0);

            if (firstJumpAble == false)
            {
                doubleJumpAble = false;
            }
            firstJumpAble = false;

        }
    }

    private void WallSliding()
    {
        isSlidingOnWall = true;
        GetComponent<Rigidbody2D>().gravityScale = slidingSpeed;
        if (partical.isParticleCycle == true)
            partical.SpwanParticle();

    }

    private void InitJump()
    {
        firstJumpAble = true;
        doubleJumpAble = true;
    }


    private bool FloorCheck()
    {


        Vector2 origin = this.transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(origin, 0.1f, direction, rayLengthFloor, floorMask);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Floor"))
            {
                InitJump();
                return true;
            }
        }

        return false;
    }

    private int WallCheck()
    {
        Vector2 origin = this.transform.position;

        Vector2 direction = Vector2.right;
        RaycastHit2D hits = Physics2D.Raycast(origin, direction, rayLength, wallMask);

        if(hits.collider != null)
        {
            if (hits.collider.CompareTag("Wall"))
            {
                InitJump();
                
                wallPos = hits.collider.transform.position;
                Trun(wallPos);
                WallSliding();

                return 1;

            }

        }
        direction = Vector2.left;

        hits = Physics2D.Raycast(origin, direction, rayLength, wallMask);

        if(hits.collider != null)
        {
            if (hits.collider.CompareTag("Wall"))
            {
                InitJump();
                
                wallPos = hits.collider.transform.position;
                Trun(wallPos);
                WallSliding();
            }
        }

        return 0;
    }

    private void Trun(Vector3 wallPos)
    {
        if (wallPos.x < transform.position.x)
        {
            this.direction = true;
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if (wallPos.x > transform.position.x)
        {
            this.direction = false;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public void PlayerHit()
    {
        playerHealth -= 1;
        PlayerDie();
    }

    private void PlayerDie()
    {
        if(playerHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
