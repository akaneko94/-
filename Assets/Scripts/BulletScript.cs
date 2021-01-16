using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    int attr;//属性

    public GameObject effect;

    public enum ELEMENT
    {
        NORMAL,
        FIRE,
        ICE,
        WIND,
        DARK,
        LIGHT,
        MAX
    }
    //private Color[] defineColor = new Color[(int)ELEMENT.MAX];
    /*//多次元配列
    private int[,] defColorRGB = {
        { 160, 160,     160 },      //NORMAL
        { 224,  50,     0 },        //FIRE
        { 132,  210,    226},       //ICE
        { 61,   154,    58},        //WIND
        { 135,  61,     204},       //DARK
        { 229,  201,    6},         //LIGHT
    };
    */
    //ジャグ配列
    int[][] defColorRGB = {
        new int[] { 160, 160,     160 },      //NORMAL
        new int[] { 224,  50,     0 },        //FIRE
        new int[] { 132,  210,    226},       //ICE
        new int[] { 61,   154,    58},        //WIND
        new int[] { 135,  61,     204},       //DARK
        new int[] { 229,  201,    6},         //LIGHT
    };
    //private int[] array = { 1,2,3,4,5};
    /*
    public static Color NORMAL_COLOR = new Color(160.0f / 255.0f, 160.0f / 255.0f, 160.0f / 255.0f);
    public static Color FIRE_COLOR = new Color(224.0f/255.0f, 50.0f / 255.0f, 0.0f / 255.0f);
    public static Color ICE_COLOR = new Color(132.0f / 255.0f, 210.0f / 255.0f, 226.0f / 255.0f);
    public static Color WIND_COLOR = new Color(61.0f / 255.0f, 154.0f / 255.0f, 58.0f / 255.0f);
    public static Color DARK_COLOR = new Color(135.0f / 255.0f, 61.0f / 255.0f, 204.0f / 255.0f);
    public static Color LIGHT_COLOR = new Color(229.0f / 255.0f, 201.0f / 255.0f, 6.0f / 255.0f);
    */

    // Use this for initialization
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        //下に落ちてしまった弾は消去する
        if (transform.position.y < -10.0f)
        {
            //爆破パーティクル
            Instantiate(effect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //爆破パーティクル
        Instantiate(effect, transform.position, Quaternion.identity);

        Destroy(gameObject);

    }

    //マテリアル色変更(RGB値指定)
    public void ChangeMaterialColor(int _r, int _g, int _b)
    {
        float red = (float)_r / 255.0f;
        float green = (float)_g / 255.0f;
        float blue = (float)_b / 255.0f;

        gameObject.GetComponent<Renderer>().material.color = new Color(red, green, blue);
    }

    //マテリアル色変更(既定カラー)
    public void ChangeMaterialColor(int _val)
    {
        //ChangeMaterialColor(defColorRGB[_val, 0], defColorRGB[_val, 1], defColorRGB[_val, 2]);//多次元配列
        ChangeMaterialColor(defColorRGB[_val][0], defColorRGB[_val][1], defColorRGB[_val][2]);//ジャグ配列
    }
}
