using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePlayManager : MonoBehaviour
{
    //막 상점에 들어간다거나 뭔가 사용하면 안될 때는 true하기.
    bool isMouseRaycastWorking = true;
    bool isCatHere = false;
    public SpriteRenderer MouseIconSprite;   //넣어두기. (나중에 Find로 가져오는게 나은가? 아님 자식으로 가져오기??)

    private void Awake()
    {
        SpriteSheetManager.Load("UIAtlas");  // 반드시 쓰기 전에 로드 할 것!
    }

    void Start()
    {
        //기본 아이콘 설정
        MouseIconSprite.sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "Icon2");
        //아이콘 체크 시작.
        StartCoroutine(IconChangeCheck());
    }

    IEnumerator IconChangeCheck()
    {
        //고양이가 클릭 범위에 있는지 없는지에 따라서 아이콘을 바꿔줘야함.
        while (isMouseRaycastWorking == true)
        {
            Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePoint += new Vector2(-1.36f, 0);   //위치 보정
            Ray2D ray = new Ray2D(mousePoint, Vector2.zero);
            RaycastHit2D[] hitObjects = Physics2D.RaycastAll(ray.origin, ray.direction);

            //있으면 이게 true로 바뀜.
            isCatHere = false;

            if (hitObjects == null)
            {
                print("아무것도 감지되지 않음. 오류 아니냐? 콜라이더 빼먹었냐?");
                MouseIconSprite.sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "MouseIcon_0");
                //오류표시용
            }
            else
            {
                //만약 뭔가 있다면 확인합니다.
                foreach (RaycastHit2D hit in hitObjects)
                {
                    GameObject obj = hit.collider.gameObject;
                    if (obj.name.Contains("CatObject"))           //만약 일반 냥이 오브젝트면
                    {
                        isCatHere = true;
                        break;
                    }
                }

                if (isCatHere)
                {
                    //냥이 있다! 발견 아이콘.
                    MouseIconSprite.sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "MouseIcon_1");
                }
                else
                {
                    //냥이 없다. 일반 아이콘.
                    MouseIconSprite.sprite = SpriteSheetManager.GetSpriteByName("UIAtlas", "Icon2");
                }
            }

            //0.1초에 한번씩 체크
            yield return new WaitForSecondsRealtime(0.1f);
        }

    }

    void Update()
    {
        if (isMouseRaycastWorking)
        {
            if (Input.GetMouseButtonDown(0))    //마우스 왼쪽 클릭 입력
            {
                MouseClick();
            }
        }
    }

    void MouseClick()
    {
        Vector2 mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePoint += new Vector2(-1.36f, 0);   //위치 보정
        Ray2D ray = new Ray2D(mousePoint, Vector2.zero);
        RaycastHit2D[] hitObjects = Physics2D.RaycastAll(ray.origin, ray.direction);

        if (hitObjects == null)
        {
            print("아무것도 감지되지 않음. 오류 아니냐? 콜라이더 빼먹었냐?");
        }
        else
        {
            int catCode = -1;
            foreach (RaycastHit2D hit in hitObjects)
            {
                GameObject obj = hit.collider.gameObject;
                if (obj.name.Contains("CatObject"))
                {
                    //고양이 확정!

                    if (obj.name.Contains("NormalCatObject"))           //만약 일반 냥이 오브젝트면
                    {
                        NormalCatScript cat = obj.GetComponent<NormalCatScript>();
                        cat.ClickNormalCatAndGet();
                        catCode = cat.normalCatCode;
                    }
                    else if (obj.name.Contains("SpecialCatObject"))     //만약 스페셜 냥이 오브젝트면
                    {
                        SpecialCatScript cat = obj.GetComponent<SpecialCatScript>();
                        cat.ClickSpecialCatAndGet();
                        catCode = cat.specialCatCode;
                    }

                    if (catCode != -1)  //catCode 입력받음.
                    {
                        //Remove : List에서 입력받은 catCode를 지움.
                        //Removeat : List에서 입력받은 index번째를 지움.
                        GameManager.Instance.CatSpawnInfos_Dictionary[1/*Test. 현재 챕터와 레벨입력하기*/][1].spawnedCatCodeList.Remove(catCode);
                        print("catCode지움!"+catCode);
                        break;
                    }
                }
            }
        }
    }
}

