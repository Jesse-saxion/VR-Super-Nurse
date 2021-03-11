using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public List<GameObject> PipeParts;
    public float ConnectedMassInfront;
    public float ConnectedMassRegular;
    public float MaximumConnectedMassScaler;
    public float MinimumConnectedMassScaler;
    public float ConnectedMassScalerStep;
    public List<GameObject> EnteredTrigger;
    public List<float> OldDistance;
    public GameObject currentInteractibleObject;
    //public float MaxAngle; //maximum angle between pipe parts
  //  public float MinAngle; //minimum angle for the pipe
   // public float Bouncines; //bounciness when pipe part reached angle limit
    private void Start()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<TubeInsertion>().Manager = this;
        for (int i =1; i<PipeParts.Count;i++)
        {
            //ConfigurableJoint joint = PipeParts[i].GetComponent<ConfigurableJoint>();
            HingeJoint joint = PipeParts[i].GetComponent<HingeJoint>();
            joint.connectedBody = PipeParts[i - 1].GetComponent<Rigidbody>();
           // CalculateConnectedMassMultiplier(i, ref joint);
            //PipeParts[i].transform.position = new Vector3(PipeParts[i - 1].transform.position.x + 1, PipeParts[i - 1].transform.position.y - 1, PipeParts[i - 1].transform.position.z);
        }
     
    }
    private void LateUpdate()
    {
       /* if (currentInteractibleObject != null)
       {
            for(int i = 0; i< EnteredTrigger.Count;i++)
            {
                float distance = Vector3.Distance(EnteredTrigger[i].transform.position, currentInteractibleObject.transform.position);
                float dif = OldDistance[i] - distance;
                EnteredTrigger[i].transform.position = new Vector3(EnteredTrigger[i].transform.position.x+dif, 
                EnteredTrigger[i].transform.position.y,
                EnteredTrigger[i].transform.position.y);
           }
        }*/
    }
   /* public void OnPipePartSelected (GameObject pipePart)
    {
        int index = PipeParts.IndexOf(pipePart);
        for (int i = 1; i < index; i++)
        {
            PipeParts[i].GetComponent<ConfigurableJoint>().connectedMassScale = ConnectedMassInfront;
        }
        for (int i = index; i < PipeParts.Count; i++)
        {
            ConfigurableJoint joint = PipeParts[i].GetComponent<ConfigurableJoint>();
            CalculateConnectedMassMultiplier(i-index, ref joint);   
        }
    }
    public void OnPipePartDeselected(GameObject pipePart)
    {
        for (int i = 1; i < PipeParts.Count; i++)
        {
            ConfigurableJoint joint = PipeParts[i].GetComponent<ConfigurableJoint>();
            CalculateConnectedMassMultiplier(i, ref joint);

        }
    }
    void CalculateConnectedMassMultiplier(int stepMultiplier, ref ConfigurableJoint joint)
    {
        joint.connectedMassScale = MinimumConnectedMassScaler + ConnectedMassScalerStep * stepMultiplier;
       if (joint.connectedMassScale > MaximumConnectedMassScaler)
       {
           joint.connectedMassScale = MaximumConnectedMassScaler;
       }
    }
    */
}
