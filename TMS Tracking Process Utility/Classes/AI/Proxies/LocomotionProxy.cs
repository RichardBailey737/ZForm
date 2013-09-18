using UnityEngine;
using System.Collections;
using BBDS.Classes;
using BBDS.Classes.AI;
using Pathfinding;

public class LocomotionProxy : ILocomotionProxy {
	
    public void Initalize()
	{
		seeker = ActorGameObject.GetComponent<Seeker>();
		currentWaypoint = 0;
		SteeringForce = Vector3.zero;
	}	
	
    public Actor ParentActor { get; set; }
	public GameObject ActorGameObject { get; set; }
	public Vector3 TargetPosition { get; set; }
	public Seeker seeker { get; private set; }
	public CharacterController controller { get; private set; }
	public Path path { get; set; }
	
	public float nextWaypointDistance = .1f;

	private int currentWaypoint = 0;
	
	public void SetRandomDestination() {}
	
	private Vector3 SteeringForce { get; set; }

    public void SetTarget(Actor TargetActor) {
		
	}
	
	public void SetTarget(float x, float y, float z) {
		TargetPosition = new Vector3(x, y, z);
	}
	
	public void GeneratePath()
	{ 
		seeker.StartPath (ActorGameObject.transform.position,TargetPosition, OnPathComplete);
	}
    
	public void OnPathComplete(Path p) {
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}
	
	
	public bool GoToTarget(MovementSpeed Speed) {
		float speed;
		switch (Speed) {
		case MovementSpeed.Walk: 
			speed = 100;
			break;
		case MovementSpeed.Run: 
			speed = 150;
			break;
		case MovementSpeed.Sprint: 
			speed = 200;
			break;
		default:
			speed = 100;
		break;
		}	
		
		Vector3 dir = path.vectorPath[currentWaypoint]-ActorGameObject.transform.position;
		if (currentWaypoint < path.vectorPath.Count -1) {
			//Middle waypoint
			dir = dir.normalized * speed * Time.deltaTime;
			SteeringForce = dir;
		} else {
			//Endpoint
			float dist = dir.magnitude;
			if (dist > .01) {
				float spd  = dist / .6f;
				spd	= Mathf.Min(spd, speed);
				SteeringForce = (dir * spd) / dist;
			}
			SteeringForce = Vector3.zero;
			return true;
		}
		
		if (Vector3.Distance(ActorGameObject.transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
			currentWaypoint++;
			return false;
		} 
		return false;
	}
	
	public void Update()
	{
		controller.SimpleMove(SteeringForce);
	}
	

}
