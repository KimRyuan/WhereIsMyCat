using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCatScript : MonoBehaviour
{
    public MoneyBankManager moneyBankManager;
    public List<Sprite> catImages = new List<Sprite>();
    private int normalCatMoneyAmount;

    private void Awake()
    {
        SpriteRenderer normalCatSpriteRenderer = GetComponent<SpriteRenderer>();
        normalCatSpriteRenderer.color = new Color(0,0,0,0); //이미지 바꾸는 동안 숨김
    }

    void Start()
    {
        int normalCatImageNumber = Random.Range(0, 10);     //0~9 (일반냥이 10마리임)
        SpriteRenderer normalCatSpriteRenderer = GetComponent<SpriteRenderer>();
        normalCatSpriteRenderer.sprite = catImages[normalCatImageNumber];
        normalCatSpriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void normalCat_FirstSetting()
    {
        normalCatMoneyAmount = Random.Range(6,10)*10;       // 60하트~90하트. (업그레이드로 돈 획득량 증가?)
                                                            //스테이지에 따라서 증가??<<그러면 첫번째 스테이지 가기싫어질듯)
    }
}
