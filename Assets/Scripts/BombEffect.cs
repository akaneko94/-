using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public float power = 1000f;
    public float radius = 5f;
    public float upwardsModifier = 10f;
    private bool flg = true;
    Rigidbody rb;

    private void Start()
    {
        
    }

    void Update()
    {
        if (flg)
        {
            flg = false;

            int layerMask = 1 << 8;
            layerMask = ~layerMask;

            Collider[] cols = Physics.OverlapSphere(this.transform.position, radius,layerMask);
            foreach (Collider cube in cols)
            {
                //BulletとPlayerタグ以外のRigidbodyがアタッチされたオブジェクトのRigidbodyに爆破の力を作用させる
                if (cube.GetComponent<Rigidbody>())
                {
                    Debug.Log(cube.name);

                    cube.GetComponent<Rigidbody>().
                        AddExplosionForce(power, this.transform.position, radius);
                }
            }
        }
    }
}
