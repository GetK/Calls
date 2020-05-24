using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Button StartGame;
    private Button StartGames;
    private Button PuaseGames;
    private Button Difficultys;
    private Button Ordinary;
    private Button Simpleness;
    private Button SetButton;
    private GameObject GameMain;
    private GameObject PuaseGame;
    private GameObject Difficulty;
    private GameObject PlayerHp;
    private GameObject SetMain;
    private AudioSource MainAudio;
    private Transform LeftPos;
    private Transform RightPos;
    private int EnemyIndex = 0;
    /// <summary>
    /// 怪物刷新时间
    /// </summary>
    public float Refresh = 2f;
    public float RefreshRight = 4f;
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        ///攻击按钮隐藏
        transform.GetChild(0).GetComponent<Transform>().gameObject.SetActive(false);
        transform.GetChild(1).GetComponent<Transform>().gameObject.SetActive(false);
        PlayerHp = transform.Find("PlayerHp").gameObject;
        PlayerHp.SetActive(false);
        GameMain = transform.Find("GameMain").gameObject;
        PuaseGame = transform.Find("PuaseGame").gameObject;
        SetMain = transform.Find("SetMain").gameObject;
        Difficulty = transform.Find("Difficulty").gameObject;
        LeftPos = GameObject.Find("EnemyListLeft").transform;
        RightPos = GameObject.Find("EnemyListRig").transform;
        ///攻击按钮隐藏
        transform.GetChild(0).GetComponent<Transform>().gameObject.SetActive(false);
        transform.GetChild(1).GetComponent<Transform>().gameObject.SetActive(false);
        SetButton = transform.Find("SetButton").GetComponent<Button>();
        SetButton.onClick.AddListener(MusicPanel);
        StartGame = transform.Find("GameMain/StartGame").GetComponent<Button>();
        StartGame.onClick.AddListener(Isgame);
        StartGames = transform.Find("PuaseGame/StartGame").GetComponent<Button>();
        StartGames.onClick.AddListener(GoonGame);
        PuaseGames = transform.Find("PuaseGame/PuaseGames").GetComponent<Button>();
        PuaseGames.onClick.AddListener(MainGame);
        Difficultys = transform.Find("Difficulty/Difficulty").GetComponent<Button>();
        Difficultys.onClick.AddListener(DifficultyGame);
        Ordinary = transform.Find("Difficulty/Ordinary").GetComponent<Button>();
        Ordinary.onClick.AddListener(OrdinaryGame);
        Simpleness = transform.Find("Difficulty/Simpleness").GetComponent<Button>();
        Simpleness.onClick.AddListener(SimplenessGame);
    }
    public void MusicPanel()
    {
        SetMain.transform.DOScale(Vector3.one,0.3f);
        Player._instance.IsMusic = false;
        Player._instance.IsNormalization();
    }

    /// <summary>
    /// 难度困难
    /// </summary>
    private void DifficultyGame()
    {
        PlayerHp.SetActive(true);
        Player._instance.StartGame();
        Difficulty.transform.DOScale(Vector3.zero, 0.3f);
        Player._instance.IsMusic = true;
        ///攻击按钮显示
        transform.GetChild(0).GetComponent<Transform>().gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<Transform>().gameObject.SetActive(true);
        Refresh = 1.5f;
        RefreshRight = 2.5f;
    }
    /// <summary>
    /// 难度一般
    /// </summary>
    private void OrdinaryGame()
    {
        PlayerHp.SetActive(true);
        Player._instance.StartGame();
        Difficulty.transform.DOScale(Vector3.zero, 0.3f);
        Player._instance.IsMusic = true;
        ///攻击按钮显示
        transform.GetChild(0).GetComponent<Transform>().gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<Transform>().gameObject.SetActive(true);
        Refresh = 2.5f;
        RefreshRight = 4f;
    }
    /// <summary>
    /// 难度简单
    /// </summary>
    private void SimplenessGame()
    {
        PlayerHp.SetActive(true);
        Player._instance.StartGame();
        Difficulty.transform.DOScale(Vector3.zero, 0.3f);
        Player._instance.IsMusic = true;
        ///攻击按钮显示
        transform.GetChild(0).GetComponent<Transform>().gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<Transform>().gameObject.SetActive(true);
        Refresh = 4.5f;
        RefreshRight = 6f;
    }
    /// <summary>
    /// 开始游戏
    /// </summary>
    public void Isgame()
    {
        GameMain.transform.DOScale(Vector3.zero, 0.3f);
        Difficulty.transform.DOScale(Vector3.one, 0.4f);
    }

    /// <summary>
    /// 继续游戏
    /// </summary>
    private void GoonGame()
    {
        Player._instance.gameObject.SetActive(true);
        Player._instance.transform.rotation = new Quaternion(0, 0, 0, 0);
        Player._instance.Hp = 100f;
        Player._instance.Score = 0;
        Player._instance.SliderHp.value = Player._instance.Hp / 100;
        Player._instance.StartGame();
        PlayerHp.SetActive(true);
        PuaseGame.transform.DOScale(Vector3.zero, 0.3f);
        Player._instance.IsGame = true;
        Player._instance.Normalization();
        ///攻击按钮显示
        transform.GetChild(0).GetComponent<Transform>().gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<Transform>().gameObject.SetActive(true);
    }

    /// <summary>
    /// 返回主页
    /// </summary>
    private void MainGame()
    {
        SceneManager.LoadScene(0);
    }
    private void Update()
    {
        if (Player._instance.IsGame == false || Player._instance.IsMusic == false)
            return;
        switch (EnemyIndex)
        {
            case 0:
                StartCoroutine("SpawnEnemyLeft");
                StartCoroutine("SpawnEnemyRight");
                EnemyIndex = 9;
                break;
            default:
                break;
        }
    }

    IEnumerator SpawnEnemyRight()
    {
        yield return new WaitForSeconds(Refresh);
        int so = Random.Range(1, 8);
        GameObject PrefabEnemy = Resources.Load<GameObject>("Enemy_" + so.ToString());
        GameObject LeftPreFabs = Instantiate(PrefabEnemy);
        LeftPreFabs.transform.SetParent(RightPos);
        LeftPreFabs.transform.localPosition = new Vector3(0, 0, 0);
        StartCoroutine("SpawnEnemyRight");
    }
    IEnumerator SpawnEnemyLeft()
    {
        yield return new WaitForSeconds(RefreshRight);
        int so = Random.Range(0, 8);
        GameObject PrefabEnemy = Resources.Load<GameObject>("EnemyLeft_" + so.ToString());
        GameObject LeftPreFabs = Instantiate(PrefabEnemy);
        LeftPreFabs.transform.SetParent(LeftPos);
        LeftPreFabs.transform.localPosition = new Vector3(0, 0, 0);
      
        StartCoroutine("SpawnEnemyLeft");
    }
}
