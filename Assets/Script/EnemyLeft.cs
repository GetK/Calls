using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeft : MonoBehaviour
{
    //[SerializeReference]
    private bool IsDie = false;
    public float MoveSpeed = 2f;
    private Transform EnemyList;

    private void Awake()
    {
        Destroy(gameObject, 6f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player._instance.Hp -= 5;
            Player._instance.SliderHp.value = Player._instance.Hp / 100;
            if (Player._instance.Hp <= 0)
            {
                EnemyList = transform.parent.transform;
                EnemyList.position = new Vector2(55, 55);
                Player._instance.SendMessage("IdeGame");
            }
        }
        else if (collision.gameObject.tag == "Knife")
        {
            Player._instance.Score++;
            Player._instance.SendMessage("UpdataScore");
            transform.GetComponent<BoxCollider2D>().enabled = false;
            IsDie = true;

        }
    }

    private void Update()
    {
        if (Player._instance.IsGame == false || Player._instance.IsMusic == false)
            return;
        transform.Translate(-Vector3.right * Time.deltaTime * MoveSpeed);
        if (IsDie)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * 10000f);
            transform.DOMove(new Vector2(10, 5), 6f);
            Destroy(gameObject, 10f);
        }
    }

}
