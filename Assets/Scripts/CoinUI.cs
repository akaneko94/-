using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoinUI : MonoBehaviour
{
    private Text targetText;
    private int maxcoin = 0;
    private int getcoin = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.targetText = this.GetComponent<Text>();
        maxcoin = GameObject.FindGameObjectsWithTag("Coin").Length;

        for(int i = 0; i < maxcoin; i++)
        {
            this.targetText.text = "Coin" + ":" + getcoin + "/" + maxcoin;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (getcoin == maxcoin)
        {
            SceneManager.LoadScene("gameclear");
            Cursor.lockState = CursorLockMode.None;

        }
    }

    public void ChangeText()
    {
        getcoin++;

        this.targetText.text = "Coin" + ":" + getcoin + "/" + maxcoin;

    }
}
