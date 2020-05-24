using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public static Player _instance;
    /// <summary>
    /// 开始游戏
    /// </summary>
    public bool IsGame=false;
    public bool IsMusic=false;
    /// <summary>
    /// 血量
    /// </summary>
    public float Hp = 100;
    /// <summary>
    /// 血条
    /// </summary>
    public Slider SliderHp;
    /// <summary>
    /// 分数
    /// </summary>
    public int Score = 0;

    public GameObject PuaseGame;

    private GameObject EnemyListLeft;
    private GameObject EnemyListRig;

    public Text ScoreText;
    private void Awake()
    {
        _instance = this;
        SliderHp.value = Hp / 100;
        EnemyListLeft = GameObject.Find("EnemyListLeft").gameObject;
        EnemyListRig = GameObject.Find("EnemyListRig").gameObject;
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// 开始游戏
    /// </summary>
    public void StartGame()
    {
        IsGame = true;
        transform.position = new Vector3(0, -1, 0);
    }
    /// <summary>
    /// 更新分数
    /// </summary>
    public void UpdataScore()
    {
        ScoreText.text = Score.ToString();
        ScoreText.transform.DOScale(Vector3.one, 0.2f);
        StartCoroutine("PuaseUpdate");
    }

    IEnumerator PuaseUpdate()
    {
        yield return new WaitForSeconds(1f);
        ScoreText.transform.DOScale(Vector3.zero, 0.2f);
    }

    public void Normalization()
    {
        EnemyListLeft.transform.position = new Vector2(4.1f, -0.52f);
        EnemyListRig.transform.position = new Vector2(-4.1f, -0.52f);
        gameObject.SetActive(true);
        transform.rotation = new Quaternion(0, 0, 0, 0);
        IsMusic = true;
    }
    public void IsNormalization()
    {
        EnemyListLeft.transform.position = new Vector2(22, 22);
        EnemyListRig.transform.position = new Vector2(22, 22);
        gameObject.SetActive(false);

    }
    public void IdeGame()
    {
        EnemyListLeft.transform.position = new Vector2(22, 22);
        EnemyListRig.transform.position = new Vector2(22, 22);
        PuaseGame.transform.DOScale(Vector3.one, 0.3f);
        IsGame = false;
        this.gameObject.SetActive(false);
    }
}
