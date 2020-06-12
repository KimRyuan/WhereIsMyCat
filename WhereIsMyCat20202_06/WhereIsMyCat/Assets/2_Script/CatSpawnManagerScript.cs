using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawnManagerScript : MonoBehaviour
{
    bool nowSpawnWorking = true;
    public GameObject normalCatObject;  //일반 고양이 오브젝트
                                        //스페셜 고양이 리스트라도 만들어야함..(다 고정된 위치라.)
    public List<GameObject> spawnPoint;
    void Start()
    {
        //코루틴 시작
        print("잘시작했니?");
        StartCoroutine(CatSpawn());
    }

    IEnumerator CatSpawn()
    {
        while (nowSpawnWorking==true)
        {
            print("잘돌고있니?");
            //테스트로 1초에 하나씩 냥이를 스폰.                                              //(일반냥이 확률 50%, 레어냥이 50%(테스트용))
            NormalCatSpawn();
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    void NormalCatSpawn()
    {
        GameObject nowCat = Instantiate(normalCatObject);

        //챕터 및 레벨에 따라 랜덤 스폰 범위를 어떻게 할지 고민중
        //챕터 레벨 가져오는걸루하자.. 레벨*2-2, 레벨*2-1가져오면 댐
        Vector2 postion1 = spawnPoint[0].transform.position;
        Vector2 postion2 = spawnPoint[1].transform.position;
        nowCat.transform.position = new Vector3(Random.Range(postion1.x, postion2.x),
                                                Random.Range(postion1.y, postion2.y)); 

    }

    void SpecialCatSpawn()
    {
        //캣만들고 똑같은 방식 ㄱ
    }
}
