using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class EnemyAgent : Agent
{
    public float speedmultiplier = 0.5f;
    public float dodgeReward = .02f;
    private bool hit = false;
    private float reward = 0;
    public GameObject player;

    public override void OnEpisodeBegin()
    {
        hit = false;
    }

    void Start() {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {   
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0];
        transform.Translate(controlSignal * speedmultiplier);

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Agent positie   
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(player.transform.localPosition);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Beam"))
        {
            hit = true;
            Destroy(collision.gameObject);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
    }
}