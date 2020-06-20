using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraClamp : MonoBehaviour
{
    public List<Transform> cameraClampPoints;
    public int level;

    float cameraX = 9.64f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraLimit(level);
    }

    public void CameraLimit(int level)  //Top : level-1, Bottom : level
    {
        int index = level - 1;
        transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.localPosition.x, cameraClampPoints[index].localPosition.x + cameraX, cameraClampPoints[index + 1].localPosition.x - cameraX),
        Camera.main.transform.localPosition.y, Camera.main.transform.localPosition.z);
    }
}
