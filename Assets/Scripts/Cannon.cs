using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject port;       // 発射口
    public GameObject ammunition; // 砲弾オブジェクト
    public float forceStrength;   // 打ち出す力の強さ

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 砲弾を複製して打ち出す処理
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject g = Instantiate(ammunition, port.transform.position, port.transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(g.transform.up * forceStrength, ForceMode.Impulse);
            Destroy(g, 5.0f);
        }

        // 左右回転処理
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(-1, 0, 0);
        }
    }
}
