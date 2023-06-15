using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private LevelVariables levelVar;

    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private int EnergyDeathValue = 1;
    [SerializeField]
    private int ScoreDeathValue = 1;
    [SerializeField]
    private int Hp = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBeam" || other.gameObject.tag == "PlayerFist")
        {
            print("Hp:" + Hp);
            Hp -= 1;

            if (Hp == 0)
            {
                print("i ded:" + EnergyDeathValue);
                levelVar.score += ScoreDeathValue;
                levelVar.energy += EnergyDeathValue;
                AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
                Destroy(gameObject);
            }
        }

        if (other.gameObject.tag == "Player")
        {
            levelVar.hp -= 1;
            Destroy(gameObject);
        }
    }
}