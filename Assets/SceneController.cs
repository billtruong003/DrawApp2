using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] bool DoneDrawing = false;
    [SerializeField] Animator ObjectAnim;
    // Start is called before the first frame update
    void Start()
    {
        DoneDrawing = false;
        ObjectAnim.SetBool("DOne", DoneDrawing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAnimClick() {
        if (DoneDrawing) {
            DoneDrawing = false;
            ObjectAnim.SetBool("DOne", DoneDrawing);
        }
        else
        {
            DoneDrawing = true;
            ObjectAnim.SetBool("DOne", DoneDrawing);
        }
    }
}
