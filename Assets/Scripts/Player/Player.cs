using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    //玩家状态机
    public enum PlayerState
    {
        GAME,//游玩状态
        DIE,//阵亡状态
        PASUE,//暂停状态
    }

    [Header("Player Info")]
    [SerializeField]
    public float player_health_point;
    [SerializeField]
    public float player_walk_speed;
    [SerializeField]
    public float player_run_speed;

    //玩家实体碰撞箱
    private new Collider2D collider2D;
    //玩家刚体
    private new Rigidbody2D rigidbody2D;

    private bool isShooting;//射击判断

    private bool isRuning;//奔跑判断

    private void Walk()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 speed_direct = new Vector2(Horizontal,Vertical).normalized;
        Debug.Log(speed_direct);
        rigidbody2D.velocity = player_walk_speed * speed_direct;

    }

    private void Run()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 speed_direct = new Vector2(Horizontal,Vertical).normalized;
        rigidbody2D.velocity = player_run_speed * speed_direct;
    }

    private void TurnToMousePosition()
    {
        Vector2 direction = MousePositionManager.Instance.MouseWorldPosition - (Vector2)gameObject.transform.position;
        gameObject.transform.right = direction;
    }

    private void Move()
    {
        if(isRuning)
        {
            Run();
        }
        else
        {
            Walk();
        }
    }

    private void DetectInput()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            isRuning = true;
        }
        else 
        {
            isRuning = false;
        }
        if(Input.GetMouseButton(0))
        {
            isShooting  = true;
        }
        else
        {
            isShooting  = false;
        }

        //如果奔跑时射击，则优先射击，取消奔跑
        if( isShooting && isRuning)
        {
            isRuning = false;
        }
    }

    private void Attack()
    {
        if(isShooting)
        {
            WeaponManager.Instance.Shoot();
        }
    }

    void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 0f;
    }

    void Start()
    {
        isRuning = false;
        isShooting  = false;
    }
    // Update is called once per frame
    void Update()
    {
        TurnToMousePosition();//朝向鼠标指向方向
        DetectInput();//检测按键输入
        Move();//移动
        Attack();//攻击
    }
}
