using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftSkill : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Animator PlayerAnim;//主角状态机
    private AudioSource SkillAudio;//音效
    private GameObject Attack;
    private void Awake()
    {
        SkillAudio = GetComponent<AudioSource>();
        SkillAudio.enabled = false;
        Attack = GameObject.Find("ERAQW_01Left");
        Attack.SetActive(false);
    }

    //攻击点击
    public void OnPointerDown(PointerEventData eventData)
    {
        SkillAudio.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        PlayerAnim.transform.rotation = new Quaternion(0, 0, 0, 0.1f);
        PlayerAnim.SetBool("IsSkill", true);
        StartCoroutine("DonstoryKnife");
        Attack.SetActive(true);
    }
    //攻击抬起
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerAnim.SetBool("IsSkill", false);
    }

    IEnumerator DonstoryKnife()
    {
        yield return new WaitForSeconds(0.6f);
        SkillAudio.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        Attack.SetActive(false);
    }



}
