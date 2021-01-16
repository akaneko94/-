using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public GameObject targetObj;
    Vector3 targetPos;

    void Start()
    {
        targetPos = targetObj.transform.position;

        // マウスカーソルを削除する
        //Cursor.visible = false;
        // マウスカーソルを画面内にロックする
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // targetの移動量分、自分（カメラ）も移動する
        transform.position += targetObj.transform.position - targetPos;
        targetPos = targetObj.transform.position;

        // マウスの移動量
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");
        // targetの位置のY軸を中心に、回転（公転）する
        transform.RotateAround(targetPos, Vector3.up, mouseInputX * Time.deltaTime * 100f);
        // カメラの垂直移動
        transform.RotateAround(targetPos, transform.right, -mouseInputY * Time.deltaTime * 100f);

        //mouseInputY = Mathf.Clamp(mouseInputY, -80, 60); //縦回転角度制限する

    }
}
