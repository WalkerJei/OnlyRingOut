﻿using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Unit
{
    private static Player instance;
    public static Player Instance
    {
        get { return instance; }
        set { instance = value; } 
    }

    // 게임 일시정지 여부
    private bool isPaused;
    public bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    new Rigidbody2D rigidbody2D;
    
    GameObject playerWeapon;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        rigidbody2D = GetComponent<Rigidbody2D>();   
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsPaused = false;
        IsDead = false;
        IsJump = false;

        transform.position = new Vector2(0, 0);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveHorizontal();
    }

    // 플레이어 이동 조작
    public void OnMove(InputAction.CallbackContext inputAction)
    {
        MoveDirection = inputAction.ReadValue<Vector2>();
        if (MoveDirection.x == 0) IsMove = false;
        else IsMove = true;

    }

    // 실질적으로 플레이어를 움직여 준다
    public void MoveHorizontal()
    {
        if (IsDead != true && IsMove == true)
        {
            // 오른쪽 이동
            if (MoveDirection.x > 0) transform.localScale = new Vector2(1, 1);
            // 왼쪽 이동
            else if (MoveDirection.x < 0) transform.localScale = new Vector2(-1, 1);

            transform.Translate(MoveDirection * moveSpeed * Time.deltaTime);
        }
    }

    // 위로 도약하는 조작
    public void OnJump(InputAction.CallbackContext inputAction)
    {
        if (inputAction.started && IsJump == false)
        {
            IsJump = true;
            rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    // 땅에 발이 닿았는지 확인
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
            IsJump = false;
    }

}
