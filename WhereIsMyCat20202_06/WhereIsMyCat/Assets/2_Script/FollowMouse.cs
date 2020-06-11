using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    bool spriteMaskFollow = false;
    public Camera mainCamera;
    void Start()
    {
        //시작하자마자 계속 따라가려다가 말았음.
        //말려던걸 말았음
        spriteMaskFollow = true;
        StartCoroutine(GoToMouse());
    }

    IEnumerator GoToMouse()
    {
        while (spriteMaskFollow)
        {
            print("시작되고 있는지 확인");
            Vector3 target = Input.mousePosition;
            target += new Vector3(0, 0, 1);
            transform.position = mainCamera.ScreenToWorldPoint(target);
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    private void OnMouseDown()
    {
        spriteMaskFollow = true;
        StartCoroutine(GoToMouse());
    }

    private void OnMouseUp()
    {
        spriteMaskFollow = false;
    }
}
