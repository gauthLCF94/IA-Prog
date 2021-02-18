using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Transform target;
    public float speed = 3;
	public float rotationSpeed = 5;
    Vector3[] path;
    int targetIndex;

	Vector3 oldTargetPos;

	Vector3 CurrentTargetPos
	{
		get
		{
			return target.position;
		}
	}

	void Start()
	{
		oldTargetPos = CurrentTargetPos;
		PathRequestManager.RequestPath(transform.position, oldTargetPos, OnPathFound);
	}

	void Update()
	{
		if (path.Length > 0)
		{
			if (CurrentTargetPos != oldTargetPos)
				PathRequestManager.RequestPath(transform.position, CurrentTargetPos, OnPathFound);
		}
		else
			PathRequestManager.RequestPath(transform.position, CurrentTargetPos, OnPathFound);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccesful)
	{
		if (pathSuccesful)
		{
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	IEnumerator FollowPath()
	{
		Vector3 currentWaypoint = path[0];

		while (true)
		{
			if (transform.position == currentWaypoint)
			{
				targetIndex++;
				if (targetIndex >= path.Length)
				{
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			// Rotation
			Vector3 targetDir = currentWaypoint - this.transform.position;
			float step = rotationSpeed * Time.deltaTime;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
			transform.rotation = Quaternion.LookRotation(newDir);
			// Avancer
			transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed*Time.deltaTime);

			yield return null;
		}
	}

	public void OnDrawGizmos()
	{
		if (path != null)
		{
			for (int i = targetIndex; i < path.Length; i++)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawCube(path[i], Vector3.one);

				if (i == targetIndex)
					Gizmos.DrawLine(transform.position, path[i]);
				else
					Gizmos.DrawLine(path[i - 1], path[i]);
			}
		}
	}
}
