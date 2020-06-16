using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawnManagerScript : MonoBehaviour
{
    #region 현재 챕터와 레벨정보 및 

    int nowChapter = 1;
    int nowLevel = 1;

    int nowCatCount;
    bool nowSpawnWorking = true;        //만약 총 고양이 갯수가 50마리 이상이거나 할 시에는 스폰 금지? (스테이지 마다 제한?)
    float catSpawnTime = 1.0f;

    public GameObject normalCatObject;  //일반 냥이 오브젝트
    public List<GameObject> normalCatLocationPointList;
    public GameObject specialCatObject; //스페셜 냥이 오브젝트
    public List<GameObject> specialCatLocationList = new List<GameObject>();        //스페셜 냥이 고정 스폰 위치(번호순 정렬)

    #endregion



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
            for (int chapter = 1; chapter <= GameManager.Instance.CatSpawnInfos_Dictionary.Count/*Max Chapter*/ ; chapter++)
            {
                if (GameManager.Instance.CatSpawnInfos_Dictionary[chapter][1].isUnlock)//만약 level 1이 해제되어있지 않다면.. 스킵.
                {
                    //레벨
                    for (int level = 1; level < GameManager.Instance.CatSpawnInfos_Dictionary[chapter].Count/*Max Level*/; level++)
                    {
                        if (GameManager.Instance.CatSpawnInfos_Dictionary[chapter][level].isUnlock)
                        {
                            CatSpawn_WithChapterLevel(chapter, level);
                        }
                    }
                    //레벨끝남
                }
            }
            //챕터끝남
        }

        //테스트로 1초에 하나씩 냥이를 스폰.
        yield return new WaitForSecondsRealtime(catSpawnTime);
    }

    void CatSpawn_WithChapterLevel(int chapter, int level)
    {
        //(일반냥이 확률 80%, 레어냥이 20%(테스트용))
        if (Random.Range(1, 11) <= 8)  //1~10. 1~8은 일반냥이. 9~10 스페셜냥이
        {
            //일반냥이 0~9.
            NormalCatSpawn();
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
                NormalCatSpawn();
            }
            else
            {
                SpecialCatSpawn(specialCatCode);
            }
        }
    }

    void NormalCatSpawn(int spawnCode = -1)
    {
        if (spawnCode == -1)    //지정번호 없을 시 임의로 소환
        {
            int[] minMax = GameManager.Instance.CatSpawnInfos_Dictionary[0][0].catCodeMinMax;
            spawnCode = Random.Range(minMax[0], minMax[1] + 1);
        }
        normalCatObject.GetComponent<NormalCatScript>().NormalCatSpawnWithCode(spawnCode);

        //챕터마다 spawnPointList를 따로따로 넣어줘야한다...
        //일반냥이는 각각의 Level 화면 안에서 소환된다.. 포인트는[레벨*2-2, 레벨*2-1]가져오면 댐

        Vector2 postion1 = normalCatLocationPointList[nowLevel * 2 - 2].transform.position;
        Vector2 postion2 = normalCatLocationPointList[nowLevel * 2 - 1].transform.position;

        //야이씨 여기 뭐 있는 것 강틑 ㅁㄹㄴㅁㄹㅇㅁ즐ㅈ므랒이므리ㅏㅈ므라므맂므랃즈미훚멀두지말드짐릗ㅈ★
        GameObject nowCat = Instantiate(normalCatObject);
        nowCat.transform.position = new Vector3(Random.Range(postion1.x, postion2.x),
                                                Random.Range(postion1.y, postion2.y));

    }

    void SpecialCatSpawn(int spawnCode)
    {
        GameObject nowCat = Instantiate(specialCatObject);
        //normalCatObject.GetComponent<SpecialCatScript>().SpecialCatSpawnWithCode(spawnCode);

        //스페셜냥이는 지정된 장소에서 소환된다.
        nowCat.transform.position = specialCatLocationList[spawnCode].transform.position;
        nowCat.GetComponent<SpecialCatScript>().specialCatCode = spawnCode;
    }
}
