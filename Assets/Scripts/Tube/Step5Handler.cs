using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step5Handler : StepHandler
{
    public int point;
    public Material markedTube;
    public GameObject ropeMesh;
    [SerializeField] public QuestionHandler questionStep5;
    [SerializeField] public Animator tvAnimator;


    public Material WaterMaterial;
    public void TubeMarked() {
        Debug.Log("Tube has been marked");
        CompleteSubStep(1);
    }

    //This method is called in Tube's children with colliders (it didn't work otherwise)
    public void CollisionDetected(Collision other)
    {    
        //When colliding with the snap zone, snap (doesn't apply for Step3 Handler collider)
        if (other.gameObject.name == "KidneyDish" && CheckIfSubstepComplete(1))
        {
            SnapTube(other.gameObject.GetComponent<GameObject>());
        }
    }

    void SnapTube(GameObject tube) {
        this.GetComponentInChildren<MeshRenderer>().material = WaterMaterial;
    }

    public void DrawMark()
    {
        switch (point)
        {
            case 0:
                markedTube.mainTextureOffset = new Vector2(0, -0.225f);
                break;
            case 1:
                markedTube.mainTextureOffset = new Vector2(0, -0.1f);
                break;
            case 2:
                markedTube.mainTextureOffset = new Vector2(0, -0.02f);
                break;
            case 3:
                markedTube.mainTextureOffset = new Vector2(0, 0.125f);
                break;
            case 4:
                markedTube.mainTextureOffset = new Vector2(0, 0.275f);
                break;
            default:
                markedTube.mainTextureOffset = new Vector2(0, 0.125f);
                break;
        }

        ropeMesh.GetComponent<MeshRenderer>().material = markedTube;
        // CompleteSubStep();
        tvAnimator.SetTrigger("QuestionAsked");
        ActivateQuestion(questionStep5);
    }
}
