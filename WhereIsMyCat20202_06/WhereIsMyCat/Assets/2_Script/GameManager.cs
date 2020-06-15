using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterLevelCatsInfo
{
    //챕터와 레벨
    public int chapter = -1;
    public int level = -1;
    public string levelName = "레벨 이름";

    //해금여부
    public bool isUnlock = false;

    //CatCode 최솟값과 최댓값
    public int[] catCodeMinMax = { -1, -1 };

    //Spawned CatCode Info
    public int spawnedCatCount = -1;                                //몇마리 소환됐는지 저장.
    public List<int> spawnedCatCodeList;     //소환된 고양이들 저장.

    //기본 생성자
    public ChapterLevelCatsInfo()
    {
    }

    //데이터 입력 생성자
    public ChapterLevelCatsInfo(int ch, int lv, string lvName, bool isUn, int ccmin, int ccmax,
                                int spawnCount, List<int> spawnedList)
    {
        chapter = ch;
        level = lv;
        levelName = lvName;

        isUnlock = isUn;

        catCodeMinMax = new int[] { ccmin, ccmax };

        spawnedCatCount = spawnCount;
        spawnedCatCodeList = spawnedList;
    }
}


public class GameManager : MonoBehaviour
{
    #region 싱글톤 패턴 instance
    private static GameManager instance;

    public static GameManager Instance
    {

        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<GameManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newSingleton = new GameObject("GameManager").AddComponent<GameManager>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    
    #endregion


    #region 챕터&레벨 고양이 스폰 데이터 관리

    /*Chapter,Level*/
    public Dictionary<int, Dictionary<int, ChapterLevelCatsInfo>> CatSpawnInfos_Dictionary = new Dictionary<int, Dictionary<int, ChapterLevelCatsInfo>>();
    

    void CatSpawnInfoDictionary_Setting()
    {
        //chapterLevelCatInfo_List 데이터 설정   
        List<ChapterLevelCatsInfo> infoList = new List<ChapterLevelCatsInfo>();

        //(나중에는 불러오기로 채워줘야함! 아니면 데이터 Save&Load 하는 곳에서 채워주던가!)

        //Chapter0
        infoList.Add(new ChapterLevelCatsInfo(0, 0, "일반냥이코드저장용", false, 0,/*~*/ 9, 0, new List<int>()));     //일반냥이 코드를 저장하기 위한 곳임.

        //Chapter1
        infoList.Add(new ChapterLevelCatsInfo(1, 1, "B의 방", true, 10,/*~*/ 19, 7, new List<int> {/*테스트용 일반냥이 소환*/ 0, 1, 2, 3, 4, 5, 6 }));
        infoList.Add(new ChapterLevelCatsInfo(1, 2, "2층 거실", false, 20,/*~*/ 30, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(1, 3, "옷방", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(1, 4, "2층 화장실", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(1, 5, "세탁실", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(1, 6, "헬스장", false, 0,/*~*/ 0, 0, new List<int>()));

        //Chapter2
        infoList.Add(new ChapterLevelCatsInfo(2, 1, "A의 방", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(2, 2, "거실", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(2, 3, "다락방", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(2, 4, "1층 화장실", false, 0,/*~*/ 0, 0, new List<int>()));

        //Chapter3
        infoList.Add(new ChapterLevelCatsInfo(3, 1, "정원 입구", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(3, 2, "꽃밭", false, 0,/*~*/ 0, 0, new List<int>()));
        infoList.Add(new ChapterLevelCatsInfo(3, 3, "정원 창고", false, 0,/*~*/ 0, 0, new List<int>()));

        Dictionary<int, ChapterLevelCatsInfo> lvDic = new Dictionary<int, ChapterLevelCatsInfo>();
        int putChapter = 0;
        for (int i = 0; i < infoList.Count; i++)
        {
            if (infoList[i].chapter != putChapter)  //챕터가 바뀔 때 Dic초기화해서 챕터를 구분함.
            {
                putChapter++;
                CatSpawnInfos_Dictionary.Add(putChapter, lvDic);
                lvDic = new Dictionary<int, ChapterLevelCatsInfo>();
            }
            lvDic.Add(infoList[i].level, infoList[i]);
        }

        infoList.Clear();  //메모리 정리까지 직접하면 좋긴한데 그냥 클리어만 해둠..
    }

    #endregion


    private void Awake()
    {
        //싱글톤 작업
        //MoneyDataLoad();
        var objs = FindObjectsOfType<GameManager>();
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        //CatSpawn 딕셔너리 작업
        CatSpawnInfoDictionary_Setting();
    }
}
