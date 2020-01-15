using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour {

	public GameObject[] spawnPrefab;

	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;
	
	public Transform chaseTarget;
	
	private float savedTime;
	private float secondsBetweenSpawning;
	public Vector3 anglesToRotate;


	// Use this for initialization
	void Start () {
		savedTime = Time.time;
		secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - savedTime >= secondsBetweenSpawning) // is it time to spawn again?
		{
			MakeThingToSpawn();
			savedTime = Time.time; // store for next spawn
			secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
		}	
	}

	void MakeThingToSpawn()
	{
        //randomize objeect to be created
        int index = Random.Range(0, (spawnPrefab.Length) -1);
		//HAseeb edit
		Quaternion zeroRot= Quaternion.Euler(0, 0, 0);
		// create a new gameObject
		//Debug.Log(transform.rotation);
		//Vector3 rotationVector = new Vector3(0, 30, 0);
		//Quaternion yRotation = Quaternion.AngleAxis(anglesToRotate.y * Time.deltaTime, Vector3.up);
		//Quaternion xRotation = Quaternion.AngleAxis(anglesToRotate.x * Time.deltaTime, Vector3.right);
		//Quaternion zRotation = Quaternion.AngleAxis(anglesToRotate.z * Time.deltaTime, Vector3.forward);
		//this.transform.rotation = yRotation * xRotation * zRotation * this.transform.rotation;
		GameObject clone = Instantiate(spawnPrefab[index], transform.position, transform.rotation) as GameObject;
		//Debug.Log(clone.transform.rotation);
		//GameObject clone = Instantiate(spawnPrefab[index]) as GameObject;
		//clone.transform.position = transform.position;
		// set chaseTarget if specified
		if ((chaseTarget != null) && (clone.gameObject.GetComponent<Chaser> () != null))
		{
			clone.gameObject.GetComponent<Chaser>().SetTarget(chaseTarget);
		}
	}

    public string GetGameObjectName(int index)
    {
        return spawnPrefab[index].name;
    }
}
