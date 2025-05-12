using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class MLPlayer : Agent
{
    // Start is called before the first frame update
    public float Force = 15f;
    private Rigidbody rb = null;
	private Transform orig = null;
	public Transform reset = null;


	public override void Initialize()
	{
		rb = this.GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation |
						 RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		
	


	}

	public override void OnActionReceived(ActionBuffers actions)
	{
		if (actions.DiscreteActions[0] == 1)
		{
			Thrust();
		}
	}

	
	
	public override void Heuristic(in ActionBuffers actionsOut)
	{
		var discreteActionsOut = actionsOut.DiscreteActions;
		discreteActionsOut[0] = 0;
		if (Input.GetKey(KeyCode.UpArrow))
		{
			discreteActionsOut[0] = 1;
		}
	}

	public override void OnEpisodeBegin()
	{
		ResetPlayer();
	}

	private void ResetPlayer()
	{
		this.transform.position = new Vector3(reset.position.x, reset.position.y, reset.position.z);
	}



	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("obstacle") == true)
		{
			AddReward(-1.0f);
			Destroy(collision.gameObject);
			EndEpisode();
		}


		
		if(collision.gameObject.CompareTag("walltop") == true )
		{
			AddReward(-1.0f);
			EndEpisode();
		}
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("wallreward") == true )
		{
			AddReward(0.1f);
		}
	}

	private void Thrust()
	{
		// Debug.Log("Spring!");
		rb.AddForce(Vector3.up * Force, ForceMode.Impulse);
	}


	// Update is called once per frame

}
