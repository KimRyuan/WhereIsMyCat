using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCatScript : MonoBehaviour
{
    private bool nowClickProcessWorking = false;
    public List<Sprite> catImages = new List<Sprite>();
    private int normalCatMoneyAmount;

    private void Awake()
    {
        SpriteRenderer normalCatSpriteRenderer = GetComponent<SpriteRenderer>();
        normalCatSpriteRenderer.color = new Color(0, 0, 0, 0); //이미지 바꾸는 동안 숨김
        NormalCat_FirstSetting();
    }

    void Start()
    {
        ClickNormalCatAndGet();
    }

    void NormalCat_FirstSetting()
    {
        int normalCatImageNumber = Random.Range(0, 10);     //0~9 (일반냥이 10마리임)
        SpriteRenderer normalCatSpriteRenderer = GetComponent<SpriteRenderer>();
        normalCatSpriteRenderer.sprite = catImages[normalCatImageNumber];
        normalCatSpriteRenderer.color = new Color(1, 1, 1, 1);
        normalCatMoneyAmount = Random.Range(6, 10) * 10;       // 60하트~90하트. (업그레이드로 돈 획득량 증가?)
                                                               //스테이지에 따라서 증가??<<그러면 첫번째 스테이지 가기싫어질듯)
    }

    void ClickNormalCatAndGet()
    {
        if (nowClickProcessWorking == false)
        {
            nowClickProcessWorking = true;
            bool result = MoneyBankManager.Instance.PlusCatLove(normalCatMoneyAmount);


            if (result)
            {
                print(normalCatMoneyAmount + "하트 획득 성공함");
                //반짝하면서 사라짐.
                //StartCoroutine(CatBecomeDisappear());
            }
            else
            {
                print(normalCatMoneyAmount + "하트 획득 실패함★★★★");
            }
        }
    }

    IEnumerator CatBecomeDisappear()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color myColor = spriteRenderer.color;
        while (myColor.a > 0.1f)    //점점 투명해짐
        {
            myColor = spriteRenderer.color;
            myColor = new Color(myColor.r, myColor.g, myColor.b, myColor.a - 0.05f);
            spriteRenderer.color = myColor;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        Destroy(this.gameObject);
    }
}
