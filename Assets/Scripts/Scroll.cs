using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scroll : MonoBehaviour
{

    // public variables
    public RectTransform center;
    public Image[] images;
    public RectTransform scrollView;
    //private variables
    private float[] distances;
    private bool isScrolling = false;
    private int imageDistance;
    private int minImageNum;
    float centerDistance;
    float smooth = 10;
    void Start()
    {
        int imageLength = images.Length;
        distances = new float[imageLength];
        imageDistance = (int)Mathf.Abs(images[1].GetComponent<RectTransform>().anchoredPosition.x - images[0].GetComponent<RectTransform>().anchoredPosition.x);
        centerDistance = center.GetComponentInParent<RectTransform>().anchoredPosition.x;
    }
    private void Update()
    {
        for (int i = 0; i < images.Length; i++)
        {
            distances[i] = Mathf.Abs(center.transform.position.x - images[i].transform.position.x);
        }
        float minDistance = Mathf.Min(distances);
        for (int j = 0; j < images.Length; j++)
        {
            if (minDistance == distances[j])
            {
                minImageNum = j;
            }
        }
        if(!isScrolling ){
            LerpToImage(minImageNum * -imageDistance);
        }

    }
     void LerpToImage(int position){
        float newX = Mathf.Lerp(position, centerDistance, Time.deltaTime * 10);
    }
    public void StartScroll(){
        isScrolling = true;
    }
    public void EndScroll(){
        isScrolling = false;
    }



}
