using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalCatScript : MonoBehaviour
{
    public int normalCatCode = 0;    //어느 일반 냥이인지 확인하는 넘버코드. (코드는 고양이 문서 참조)
    private bool nowClickProcessWorking = false;
    //public List<Sprite> catImages = new List<Sprite>(); 아틀라스 써서 이거 안씀.
    private int normalCatLoveAmount;

    private bool isImageChanging = false;

    private void Awake()
    {
        SpriteRenderer normalCatSpriteRenderer = GetComponent<SpriteRenderer>();
        normalCatSpriteRenderer.color = new Color(1, 1, 1, 0); 
        //Code와 위치가 입력되기 전까지 숨김
    }

    public void NormalCatSpawnSetting_WithCode(int spawnCode)
    {
        normalCatLoveAmount = Random.Range(6, 10) * 10;       // 60하트~90하트. (업그레이드로 돈 획득량 증가?)

        normalCatCode = spawnCode;
        SpriteRenderer normalCatSpriteRenderer = GetComponent<SpriteRenderer>();
        
        //아틀라스 로드는 CatSpawnManagerScript에서 함.
        normalCatSpriteRenderer.sprite = SpriteSheetManager.GetSpriteByName("SpriteAtlas", "Cat_"+spawnCode);
        StartCoroutine(CatBecomeAppear());
        //normalCatSpriteRenderer.color = new Color(1, 1, 1, 1);
    }

    void ClickNormalCatAndGet()
    {
        if (nowClickProcessWorking == false)
        {
            nowClickProcessWorking = true;
            bool result = MoneyBankManager.Instance.PlusCatLove(normalCatLoveAmount);


            if (result)
            {
                print(normalCatLoveAmount + "하트 획득 성공함");
                //반짝하면서 사라짐.
                StartCoroutine(CatBecomeDisappear());
            }
            else
            {
                print(normalCatLoveAmount + "하트 획득 실패함★★★★");
            }
        }
    }

    IEnumerator CatBecomeDisappear()
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
        while (myColor.a > 0.1f)    //점점 투명해짐
        {
            myColor = spriteRenderer.color;
            myColor = new Color(myColor.r, myColor.g, myColor.b, myColor.a - 0.05f);
            spriteRenderer.color = myColor;
            yield return new WaitForSecondsRealtime(0.05f);
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
}
