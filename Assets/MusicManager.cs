using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioSource MainMusic;
    public AudioSource SkillMusic;
    public AudioSource SkillMusisc;
    private Button Button;
    private Button PuaseGame;
    private Button Game;

    bool IsMusic = true;
    private Slider Music;


    private void Awake()
    {
        Button = transform.Find("txt_Music/Button").GetComponent<Button>();
        Button.onClick.AddListener(MusicGame);
        PuaseGame = transform.Find("PuaseGame").GetComponent<Button>();
        PuaseGame.onClick.AddListener(PuaseGames);
        Game = transform.Find("Game").GetComponent<Button>();
        Game.onClick.AddListener(SetGame);
        Music = transform.Find("Music/Slider").GetComponent<Slider>();
        MainMusic.volume = Music.value;
        SkillMusic.volume = Music.value;
        SkillMusisc.volume = Music.value;
    }
    public void MusicGame()
    {
        IsMusic = !IsMusic;
        if (IsMusic)
        {
            transform.Find("txt_Music/Button/Text").GetComponent<Text>().text = "关";
            MainMusic.enabled = true;
            SkillMusic.enabled = true;
            SkillMusisc.enabled = true;
        }
        else
        {
            transform.Find("txt_Music/Button/Text").GetComponent<Text>().text = "开";
            MainMusic.enabled = false;
            SkillMusic.enabled = false;
            SkillMusisc.enabled = false;
        }
    }
    public void PuaseGames()
    {
        Application.Quit();
    }
    public void SetGame()
    {
        Player._instance.Normalization();
        transform.DOScale(Vector3.zero, 0.3f);
        Player._instance.Normalization();
    }
    private void Update()
    {
        if(MainMusic.volume != Music.value|| SkillMusic.volume != Music.value || SkillMusisc.volume != Music.value)
        {
            MainMusic.volume = Music.value;
            SkillMusic.volume = Music.value;
            SkillMusisc.volume = Music.value;
        }
    }
}
