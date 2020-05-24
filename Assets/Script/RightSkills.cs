using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightSkills : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private AudioSource SkillAudio;
    public Animator PlayerAnims;
    private GameObject Attacks;
    private void Awake()
    {
        SkillAudio = GetComponent<AudioSource>();
        SkillAudio.enabled = false;
        Attacks = GameObject.Find("ERAQW_01Right");
        Attacks.transform.position = new Vector2(0.58f, -0.73f);
        Attacks.SetActive(false);
    }

    //攻击点击
    public void OnPointerDown(PointerEventData eventData)
    {
        SkillAudio.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        PlayerAnims.transform.rotation = new Quaternion(0,180f,0,0.1f);
        PlayerAnims.SetBool("IsSkill", true);
        StartCoroutine("DonstoryKnife");
        Attacks.SetActive(true);
    }
    //攻击抬起
    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerAnims.SetBool("IsSkill", false);
    }

    IEnumerator DonstoryKnife()
    {
        yield return new WaitForSeconds(0.6f);
        SkillAudio.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        Attacks.SetActive(false);
    }
   
}
