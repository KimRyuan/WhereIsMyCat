﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCatScript : MonoBehaviour
{
    public int specialCatCode;    //어느 스페셜 냥이인지 확인하는 넘버코드. (코드는 고양이 문서 참조)
    private bool nowClickProcessWorking = false;
    //public List<Sprite> specialCatImages = new List<Sprite>();    //아틀라스 써서 안써두댐!
    private int specialCatLoveAmount;
    private int specialCatStarAmount;

    private bool isImageChanging = false;

    private void Awake()
    {
        SpriteRenderer specialCatSpriteRenderer = GetComponent<SpriteRenderer>();
        specialCatSpriteRenderer.color = new Color(1, 1, 1, 0);
        //Code와 위치가 입력되기 전까지 숨김
    }

    public void SpecialCatSpawnSetting_WithCode(int spawnCode)
    {
        specialCatLoveAmount = Random.Range(6, 10) * 10;        // 60하트~90하트. (업그레이드로 돈 획득량 증가?)
        specialCatStarAmount = Random.Range(0, 3);              // 0~2스타.       (고정??? 아님 업글? ㅎ,ㅁ...)

        specialCatCode = spawnCode;
        SpriteRenderer normalCatSpriteRenderer = GetComponent<SpriteRenderer>();

        //아틀라스 로드는 CatSpawnManagerScript에서 함.
        normalCatSpriteRenderer.sprite = SpriteSheetManager.GetSpriteByName("SpriteAtlas", "Cat_" + spawnCode);
        //이미지에 맞춰서 콜라이더 리셋!
        ResetCollider_ForCatObject();

        StartCoroutine(CatBecomeAppear());
        //normalCatSpriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void ClickSpecialCatAndGet()
    {
        GetComponent<PolygonCollider2D>().enabled = false;
        if (nowClickProcessWorking == false)
        {
            nowClickProcessWorking = true;
            bool result1 = MoneyBankManager.Instance.PlusCatLove(specialCatLoveAmount);
            bool result2 = MoneyBankManager.Instance.PlusCatStar(specialCatStarAmount);


            if (result1 && result2)
            {
                print(specialCatLoveAmount + "하트" + specialCatStarAmount + " 스타 획득 성공함");
                //반짝하면서 사라짐.
                StartCoroutine(CatBecomeDisappear());
            }
            else
            {
                print(specialCatLoveAmount + "하트랑 스타 획득 실패함★★★★");
            }
        }
    }

    IEnumerator CatBecomeDisappear()
    {
        if (isImageChanging == true)   //이미 바뀌는 중엔 바뀌면 안됨. 입력받고 기다리기. (나타나고 있는데 획득하면 꼬임;)
        {
            while (isImageChanging)
            {
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
        isImageChanging = true;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color myColor = spriteRenderer.color;
        while (myColor.a > 0.1f)    //점점 투명해짐
        {
            myColor = spriteRenderer.color;
            myColor = new Color(myColor.r, myColor.g, myColor.b, myColor.a - 0.05f);
            spriteRenderer.color = myColor;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        isImageChanging = false;    //작업 끝남
        Destroy(this.gameObject);
    }

    IEnumerator CatBecomeAppear()
    {
        if (isImageChanging == true)   //이미 바뀌는 중엔 바뀌면 안됨. 입력받고 기다리기.
        {
            while (isImageChanging)
            {
                yield return new WaitForSecondsRealtime(0.5f);
            }
        }
        isImageChanging = true;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color myColor = spriteRenderer.color;
        while (myColor.a < 1f)    //점점 선명해짐
        {
            myColor = spriteRenderer.color;
            myColor = new Color(myColor.r, myColor.g, myColor.b, myColor.a + 0.05f);
            spriteRenderer.color = myColor;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        isImageChanging = false;    //작업 끝남
    }

    void ResetCollider_ForCatObject()
    {
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }
}
