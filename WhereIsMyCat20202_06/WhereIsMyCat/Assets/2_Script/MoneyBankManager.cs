using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBankManager : MonoBehaviour
{
    private int catLoveAmount;
    private int catStarAmount;
    private static MoneyBankManager instance;

    public static MoneyBankManager Instance
    {
        get
        {
            if (Instance == null)
            {
                var obj = FindObjectOfType<MoneyBankManager>();
                if (obj != null)
                {
                    instance = obj;
                    Destroy(obj);
                }
                else
                {
                    ///var newMoneyBankManager = new GameObject("MoneyBankManager").AddComponent<MoneyBankManager>();
                    instance = new MoneyBankManager();
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    private void Awake()    
    {
        MoneyDataLoad();
    }

    private void Start()
    {
        
    }

    //냥사랑 +- 하는곳
    public bool PlusCatLove(int plusLove)
    {
        if (plusLove >= 0)
        {
            catLoveAmount += plusLove;
            return true;
        }
        else
        {
            //들어온 돈이 -라고?? 오류닥!!!!!!!!!!!!!!!!
            return false;
        }

    }
    public bool MinusCatLove(int minusLove)
    {
        if ((catLoveAmount >= minusLove) && (minusLove >= 0))
        {
            catLoveAmount += minusLove;
            return true;
        }
        else
        {
            return false;
        }
    }

    //냥스타 +- 하는곳
    public bool PlusCatStar(int plusStar)
    {
        if (plusStar >= 0)
        {
            catStarAmount += plusStar;
            return true;
        }
        else
        {
            //들어온 돈이 -라고?? 오류닥!!!!!!!!!!!!!!!!
            return false;
        }
    }
    public bool MinusCatStar(int minusStar)
    {
        if ((catStarAmount >= minusStar)&&(minusStar>=0))
        {
            catStarAmount += minusStar;
            return true;
        }
        else
        {
            //돈이 없닭!!!!!!!!!!!!!!!!
            return false;
        }
    }

    #region DataLoadSave

    private void MoneyDataLoad()    //핸드폰 내부데이터에서 저장된 재화 불러오기
    {
        catLoveAmount = 0;//아직 불러올데가 없어서 이케 냅둠
        catStarAmount = 0;
    }

    private void MoneyDataSave()  //핸드폰 내부데이터에서 현재 재화 저장하기
    {
        //저장공간 생기면 한댜아아
    }

    #endregion
}
