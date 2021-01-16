using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public GameObject PlayerBox;
    private GameObject UI;
    
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("CoinUI");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(90, 0, 0) * Time.deltaTime * 5);
    }

    private void OnTriggerEnter(Collider other)
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == PlayerBox.tag)
        {
            Destroy(this.gameObject);

            UI.gameObject.GetComponent<CoinUI>().ChangeText();
            Debug.Log("GETCOIN");
        }

    }
}
