using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpPlayerManage : MonoBehaviour
{
    private PlayerMovement player;
    public Image[] hp;
    public int CurHp;
    public float immuneTime;

    void Start(){
        player = GetComponent<PlayerMovement>();
    }

    private IEnumerator LossHp()
    {
        hp[CurHp].enabled = false;
        GetComponent<Animator>().SetLayerWeight(1,1);
        Physics2D.IgnoreLayerCollision(6, 7);
        yield return new WaitForSeconds(immuneTime);
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            CurHp--;
            if(CurHp <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }else{
                StartCoroutine(LossHp());
                StartCoroutine(player.KnockBack(0.5f, 5, player.transform.position));
            }
        }
    }
}
