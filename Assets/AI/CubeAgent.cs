using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using Unity.MLAgents;
using UnityEngine;
using JetBrains.Annotations;

public class CubeAgent : Agent
{
    public float jumpForce = 10f;
    public float moveSpeed = 1f;
    public float timeBetweenJumps = 1f;

    private Rigidbody rb;
    private bool isGrounded;
    private float timeSinceLastJump = 0f;

    float reward;

    // Define the possible actions that the agent can take
    enum AgentAction { Jump, Wait }
    // The current action that the agent is taking
    AgentAction currentAction;

    public override void Initialize()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        timeSinceLastJump = timeBetweenJumps;
        reward = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(rb.velocity);
        sensor.AddObservation(isGrounded);
        sensor.AddObservation(timeSinceLastJump);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Choose the current action based on the action received from the agent
        currentAction = (AgentAction)actions.DiscreteActions[0];

        // Perform the current action

        if (isGrounded && timeSinceLastJump >= timeBetweenJumps)
        {
            switch (currentAction)
            {
                case AgentAction.Jump:
                    rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
                    isGrounded = false;
                    timeSinceLastJump = 0f;
                    reward -= 1f;
                    AddReward(reward);
                    print("cr: " + reward);
                    break;
                case AgentAction.Wait:
                    reward += 0.1f;
                    AddReward(reward);
                    break;
            }
        }

        timeSinceLastJump += Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void Hit()
    {
        reward -= 100f;
        AddReward(reward);
        print("ended by hit, reward = " + reward);
        EndEpisode();
    }
    
    public void Reward()
    {
        reward += 100f;
        AddReward(reward);
    }
}