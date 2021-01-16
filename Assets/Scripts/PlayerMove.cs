using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    float inputHorizontal;
    float inputVertical;
    Rigidbody rb;

    public float moveSpeed = 8f;

    // 現在の加速度
    protected Vector3 velocity;

    //public int getcoin = 0;

    //[SerializeField]
    //protected float jumpSpeed = 7f;
    //[SerializeField]
    //protected float maxFallSpeed = 20f;
    //[SerializeField]
    //protected float gravity = 15f;

    // 最小ジャンプフラグ
    //protected bool minJumpFlag = false;

    // 加速度計算用の位置情報
    //protected Vector3 oldPosition;

    // キャラクターコントローラ
    //protected CharacterController characterController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //characterController = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (Input.GetKey(KeyCode.Escape)) Quit();

        if (transform.position.y < -50.0f)
        {
            SceneManager.LoadScene("gameover");
            Cursor.lockState = CursorLockMode.None;

        }

        //if (Input.GetButtonDown("Jump"))
        //{
        //    inputJumpButton = true;
        //}

        //if (Input.GetButtonUp("Jump"))
        //{
        //    inputJumpButton = false;
        //}
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

    //public void GetCoin()
    //{
    //    getcoin++;
    //}

    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        // キャラクターの向きを進行方向に
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }

        Vector3 moveDirection = Vector3.zero;

        //// ジャンプ移動反映
        //moveDirection += CalcJumping(moveDirection);

        //// CharacterControllerで移動
        //characterController.Move(moveDirection * Time.deltaTime);

        //// 移動処理後の加速度を計算
        //velocity = (transform.position - oldPosition) / Time.deltaTime;

        //// 着地している場合は最小ジャンプフラグをfalseにする
        //if (characterController.isGrounded)
        //{
        //    minJumpFlag = false;
        //}
    }

    //protected Vector3 CalcJumping(Vector3 moveDirection)
    //{
    //    // 着地時にジャンプボタンが押された場合は加速度を与える
    //    if (inputJumpButton && characterController.isGrounded)
    //    {
    //        velocity.y = jumpSpeed;
    //    }

    //    // 空中でジャンプボタンが押されていない場合は加速度を0に戻す
    //    if (!inputJumpButton && !characterController.isGrounded && !minJumpFlag)
    //    {
    //        if (0 <= velocity.y)
    //        {
    //            velocity.y = 0;
    //        }
    //        minJumpFlag = true;
    //    }

    //    moveDirection.y = velocity.y - gravity * Time.deltaTime;
    //    moveDirection.y = Mathf.Max(moveDirection.y, -maxFallSpeed);

    //    return moveDirection;
    //}
}
