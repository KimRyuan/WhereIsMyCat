using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawnManagerScript : MonoBehaviour
{
    public GameObject normalCatObject;  //일반 고양이 오브젝트
    
    void Start()
    {
        //코루틴 시작
        StartCoroutine(CatSpawn());
    }

    IEnumerator CatSpawn()
    {        
        //테스트로 1초에 하나씩 냥이를 스폰.                                              //(일반냥이 확률 50%, 레어냥이 50%(테스트용))
        normalCatSpawn();
        yield return new WaitForSecondsRealtime(1.0f);
    }

    void normalCatSpawn()
    {
        GameObject nowCat = Instantiate(normalCatObject);

        //챕터 및 레벨에 따라 랜덤 스폰 범위를 어떻게 할지 고민중
        nowCat.transform.position = new Vector3(0, 0); 
    }

    void specialCatSpawn()
    {

    }
}
