using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawnManagerScript : MonoBehaviour
{
    #region 현재 챕터와 레벨정보 및 

    int nowChapter = 1; //나중에 씬 이동할 때 현재 챕터랑 레벨 불러올거임. (플레이어 프리펩이 줄거임!)
    int nowLevel = 1;
    int catMaxCount = 30;
    
    bool nowSpawnWorking = true;        //만약 총 고양이 갯수가 50마리 이상이거나 할 시에는 스폰 금지? (스테이지 마다 제한?)
    float catSpawnTime = 0.1f;

    public GameObject normalCatObject;  //일반 냥이 오브젝트
    public List<GameObject> normalCatLocationPointList;
    public GameObject specialCatObject; //스페셜 냥이 오브젝트
    public List<GameObject> specialCatLocationList = new List<GameObject>();        //스페셜 냥이 고정 스폰 위치(번호순 정렬)

    #endregion

    private void Awake()
    {
        SpriteSheetManager.Load("SpriteAtlas");  // 반드시 쓰기 전에 로드 할 것!
    }

    void Start()
    {
        LoadCats(); //전에 있던 고양이 로딩
        //코루틴 시작
        StartCoroutine(InGameCatAutoSpawn());
    }

    void LoadCats()
    {
        //게임종료전에 저장된 고양이들을 전부 불러온다. (이 경우 (강제)종료될 때 저장된 냥이 + 경과한 시간분의 냥이 전부 다시 소환해야함.)
    }

    IEnumerator InGameCatAutoSpawn()
    {
        while (nowSpawnWorking == true)
        {
            //나중에 새로운 씬 불러오기 할 때 >> (경과된 시간/스폰타임)마리를 바로 스폰하는 것으로 한다.

            //챕터&레벨마다 하나씩 공평하게 소환해야한다.★★★★★★
            //챕터
            for (int chapter = 1; chapter <= GameManager.Instance.CatSpawnInfos_Dictionary.Count - 1/*Max Chapter. 0챕터가 있어서 count-1해야함.*/ ; chapter++)
            {
                if (GameManager.Instance.CatSpawnInfos_Dictionary[chapter][1].isUnlock)//만약 level 1이 해제되어있지 않다면.. 스킵.
                {
                    //레벨
                    for (int level = 1; level < GameManager.Instance.CatSpawnInfos_Dictionary[chapter].Count/*Max Level*/; level++)
                    {
                        if (GameManager.Instance.CatSpawnInfos_Dictionary[chapter][level].isUnlock)
                        {
                            if (GameManager.Instance.CatSpawnInfos_Dictionary[chapter][level].spawnedCatCodeList.Count < catMaxCount)
                            {
                                CatSpawn_WithChapterLevel(chapter, level);
                            }
                            else
                            {
                                //print("고양이 갯수 초과!");
                            }
                        }
                    }
                    //레벨끝남
                }
            }
            //챕터끝남

            //catSpawnTime만큼 기다림
            yield return new WaitForSecondsRealtime(catSpawnTime);
        }

    }

    void CatSpawn_WithChapterLevel(int chapter, int level)
    {
        //print("캣스폰에서 입력된 챕터" + chapter + "레벨" + level);
        //(일반냥이 확률 80%, 레어냥이 20%(테스트용))
        if (Random.Range(1, 11) <= 8)  //1~10. 1~8은 일반냥이. 9~10 스페셜냥이
        {
            //일반냥이 0~9.
            NormalCatSpawn(chapter, level);
        }
        else
        {   //스페셜냥이 현재 Chapter와 Level에 따라 다름.
            int[] minMax = GameManager.Instance.CatSpawnInfos_Dictionary[chapter][level].catCodeMinMax;
            //C1 L1 10~19.
            //C1 L2 20~30.
            int specialCatCode = Random.Range(minMax[0], minMax[1] + 1);

            //이미 소환 되어있는지 체크
            bool isAlreadySpawned = false;
            foreach (int code in GameManager.Instance.CatSpawnInfos_Dictionary[chapter][level].spawnedCatCodeList)
            {
                if (code == specialCatCode)
                {
                    isAlreadySpawned = true;
                }
            }

            //이미 소환된 고양이라면 일반고양이로 바꿈
            if (isAlreadySpawned)
            {
                //print("중복된 스페셜 냥이가 일반냥이로 바뀌었습니다." + specialCatCode);
                NormalCatSpawn(chapter, level);
            }
            else
            {
                SpecialCatSpawn(chapter, level, specialCatCode);
            }
        }
    }

    void NormalCatSpawn(int chapter, int level, int spawnCode = -1)
    {
        //print("입력받은 일반냥이" + spawnCode +"-1일시 임의로 설정");
        if (spawnCode == -1)    //지정번호 없을 시 임의로 소환
        {
            int[] minMax = GameManager.Instance.CatSpawnInfos_Dictionary[0][0].catCodeMinMax;
            spawnCode = Random.Range(minMax[0], minMax[1] + 1);
        }
        //소환 목록에 추가
        GameManager.Instance.CatSpawnInfos_Dictionary[chapter][level].spawnedCatCodeList.Add(spawnCode);
        //print("일반냥이 소환" + spawnCode);

        //소환
        GameObject nowCat = Instantiate(normalCatObject);

        //위치 조정. (일반 냥이는 랜덤한 위치에서 소환)
        Vector2 postion1 = normalCatLocationPointList[nowLevel * 2 - 2].transform.position;
        Vector2 postion2 = normalCatLocationPointList[nowLevel * 2 - 1].transform.position;
        nowCat.transform.position = new Vector3(Random.Range(postion1.x + 1, postion2.x - 1),   //왼쪽이 -, 오른쪽이 +
                                                Random.Range(postion1.y - 1, postion2.y + 1));  //아래가 -, 윗쪽이 +

        //기본 셋팅
        nowCat.GetComponent<NormalCatScript>().NormalCatSpawnSetting_WithCode(spawnCode);
    }

    void SpecialCatSpawn(int chapter, int level, int spawnCode)
    {
        GameManager.Instance.CatSpawnInfos_Dictionary[chapter][level].spawnedCatCodeList.Add(spawnCode);
        //print("스페셜냥이 소환" + spawnCode);
        //소환
        GameObject nowCat = Instantiate(specialCatObject);

        //위치 조정. (스페셜 냥이는 지정된 위치에서 소환)
        for (int num = 0; num < specialCatLocationList.Count; num++)
        {

            string[] token = specialCatLocationList[num].name.Split('_');
            if (token[1].Equals(spawnCode.ToString()))  //token : specialCat_숫자_Location 형식
            {
                nowCat.transform.position = specialCatLocationList[num].transform.position;
                //print(token[1] + "과" + spawnCode + "가 같습니다.");
                break;
            }
            else
            {
                //print(token[1] + "과" + spawnCode + "가 다릅니다.");
            }
        }

        //기본 셋팅
        nowCat.GetComponent<SpecialCatScript>().SpecialCatSpawnSetting_WithCode(spawnCode);
    }
}
