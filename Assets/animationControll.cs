using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class animationControll : MonoBehaviour
{
    const int BlinkTrack = 1; // Track (đường dẫn) được sử dụng cho hiệu ứng nhấp nháy
    public AnimationReferenceAsset Animation; // Tham chiếu đến animation nhấp nháy
    public GameObject Model;
    [SerializeField] bool readyforAnim = false;
    SkeletonAnimation skeletonAnimation; 
    // Start is called before the first frame update
    public void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (readyforAnim)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, "animation", true);
            Model.SetActive(true);
        }
        else
        {
            skeletonAnimation.AnimationState.ClearTrack(1);
            Model.SetActive(false);
        }
    }
    public void trueFCheck(){
        if (readyforAnim)
            readyforAnim = false;
        else
            readyforAnim =true;
    }
}
