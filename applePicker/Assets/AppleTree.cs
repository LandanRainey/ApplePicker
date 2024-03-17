using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
	[Header("Inscribed")]
	//prefab for instantiating apples
	public GameObject applePrefab;
	
	//AppleTree move speed
	public float speed = 0.1f;
	
	//AppleTree turn distance
	public float leftAndRightEdge = 10f;
	
	//AppleTree turn chance
	public float changeDirChance = 0.1f;
	
	//seconds btw new apple instantiations
	public float appleDropDelay = 1f;
		
    // Start is called before the first frame update
    void Start()
    {
        //start dropping apples
		Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
		apple.transform.position = transform.position;
		Invoke("DropApple", appleDropDelay);
    }


    // Update is called once per frame
    void Update()
    {
        //basic movement
		Vector3 pos = transform.position;
		pos.x += speed + Time.deltaTime;
		transform.position = pos;
		
		//change direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs(speed); //move right
		}
		else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs(speed); //move left
		}
		
    }

	void FixedUpdate()
    {
		//random direction changes are time-based due to FixedUpdate
		if (Random.value < changeDirChance) {
			speed *= -1;
		}
	}

}
