using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMark : MonoBehaviour
{
    public int point;
    public Material markedTube;
    public GameObject ropeMesh;

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
    }
}
