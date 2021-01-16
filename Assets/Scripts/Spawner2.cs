using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject ThrowingObject; //射出されるオブジェクト
    private Vector3 TargetPosition; //到達地点
    private float ThrowingAngle; //射出される角度

    public int SpwaneFPS = 60;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        ThrowingAngle = 45.0f;
        TargetPosition = new Vector3(0, 0, 0);
        //Floar_x = FloarObject.transform.lossyScale.x / 2;
        //Floar_z = FloarObject.transform.lossyScale.z / 2;
        //Debug.Log(-Floar_x);
        //Debug.Log(-Floar_z);
        //Debug.Log(Floar_x);
        //Debug.Log(Floar_z);

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            //干渉しないようにisTriggerをつける
            collider.isTrigger = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(count % 60);
        //〇〇フレームに1回
        if (count % SpwaneFPS == 0)
        {
            //到達地点を設定する
            TargetPosition.x = Random.Range(-40.0f, 40.0f);
            TargetPosition.z = Random.Range(-40.0f, 40.0f);
            //Debug.Log(TargetPosition);

            //Debug.Log(TargetPosition.y);
            //Debug.Log(TargetPosition.z);
            Throwing();

            count = 0;
        }
        count++;

    }

    private void Throwing()
    {
        if (ThrowingObject != null)
        {
            // bulletオブジェクトの生成
            GameObject bullet = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);

            // 射出角度
            float angle = ThrowingAngle;
            //float angle = 0;
            //Debug.Log(angle);

            // 射出速度を算出
            Vector3 velocity = CalculateVelocity(this.transform.position, TargetPosition, angle);
            //Debug.Log(velocity);

            //弾の向きを回転させる
            Vector3 bulletRotate = new Vector3(45 + Random.Range(45.0f, 90.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
            bullet.transform.Rotate(bulletRotate);

            // 射出
            Rigidbody rid = bullet.GetComponent<Rigidbody>();
            rid.AddForce(velocity * rid.mass, ForceMode.Impulse);

            //coin.GetComponent<CoinScript>().ChangeMaterialColor(Random.Range(0, 128), Random.Range(128, 255), Random.Range(0, 64));
            bullet.GetComponent<BulletScript>().ChangeMaterialColor(Random.Range(0, 6));
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }
    }

    /// <summary>
    /// 標的に命中する射出速度の計算
    /// </summary>
    /// <param name="pointA">射出開始座標</param>
    /// <param name="pointB">標的の座標</param>
    /// <returns>射出速度</returns>
    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;

        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));

        // 垂直方向の距離y
        float y = pointA.y - pointB.y;

        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }

}
