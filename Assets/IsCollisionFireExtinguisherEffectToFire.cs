using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCollisionFireExtinguisherEffectToFire : MonoBehaviour
{
    public GameObject frontDoorObstacle;
    public Vector3 scale1;
    public Vector3 scale2;
    public Vector3 scale3;
    public Vector3 scale4;
    public Vector3 scale5;
    public Vector3 scale6;
    // Start is called before the first frame update
    void Start()
    {
        scale1 = new Vector3(0.525f, 0.24407625f, 0.4262775f);
        scale2 = new Vector3(0.39375f, 0.16227175f, 0.284185f);
        scale3 = new Vector3(0.175f, 0.081135875f, 0.1420925f);

        scale4 = new Vector3(0.1874924f, 0.525f, 0.3640153f);
        scale5 = new Vector3(0.1874924f, 0.39375f, 0.3640153f);
        scale6 = new Vector3(0.1874924f, 0.174f, 0.3640153f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (!frontDoorObstacle)
        {
            frontDoorObstacle = GameObject.Find("FrontDoorObstacle");
        }
        if (other.tag == "last_fire")
        {
            Debug.Log(GameManager.Instance.countInFire);
            if (GameManager.Instance.countInFire == 3)
            {
                frontDoorObstacle.transform.GetChild(2).transform.localScale = scale1;
                frontDoorObstacle.transform.GetChild(2).GetChild(1).transform.localScale = scale4;
                GameManager.Instance.countInFire--;
            }
            else if (GameManager.Instance.countInFire == 2)
            {
                frontDoorObstacle.transform.GetChild(2).transform.localScale = scale2;
                frontDoorObstacle.transform.GetChild(2).GetChild(1).transform.localScale = scale5;
                GameManager.Instance.countInFire--;
            }
            else if (GameManager.Instance.countInFire == 1)
            {
                frontDoorObstacle.transform.GetChild(2).transform.localScale = scale3;
                frontDoorObstacle.transform.GetChild(2).GetChild(1).transform.localScale = scale6;
                GameManager.Instance.countInFire--;
            }
            else
            {
                frontDoorObstacle.transform.GetChild(1).gameObject.SetActive(false);
                frontDoorObstacle.transform.GetChild(2).gameObject.SetActive(false);
                frontDoorObstacle.transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;
                frontDoorObstacle.transform.GetChild(2).gameObject.tag = "Untagged";
            }
        }
    }

}