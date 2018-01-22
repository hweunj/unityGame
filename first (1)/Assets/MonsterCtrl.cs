using UnityEngine;
using System.Collections;

public class MonsterCtrl : MonoBehaviour {

    private int count = 0;
    private Animator animator;
	public enum MonsterState { idle, trace, attack, die	};
	public MonsterState monsterState = MonsterState.idle;

	private Transform MonsterTr;
	private Transform PlayerTr;
	private NavMeshAgent nvAgent;

	public float traceDist = 10.0f;
	public float attackDist = 2.0f;
	private bool isDie = false;

	public GameObject bloodEffect;
	public GameObject bloodDecal;

    public GameObject enemy;
    public float spawnTime = 10000.0f;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
		MonsterTr = this.gameObject.GetComponent<Transform>();
		PlayerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
		nvAgent = this.gameObject.GetComponent<NavMeshAgent>();
		animator = this.gameObject.GetComponent<Animator>();
		nvAgent.destination=PlayerTr.position;

		StartCoroutine(this.CheckMonsterState());
		StartCoroutine(this.MonsterAction());
        InvokeRepeating("spawn", spawnTime, spawnTime);
	}

	IEnumerator CheckMonsterState(){
		while (!isDie) {
			yield return new WaitForSecondsRealtime (0.2f);
			float dist = Vector3.Distance(PlayerTr.position, MonsterTr.position);
			if (dist <= attackDist)
				monsterState = MonsterState.attack;
			else if (dist <= traceDist)
				monsterState = MonsterState.trace;
			else
				monsterState = MonsterState.idle;
		}
	}

	IEnumerator MonsterAction(){
		while (!isDie) {
			switch (monsterState) {
			case MonsterState.idle:
				nvAgent.Stop ();
				animator.SetBool("IsTrace", false);
				break;
			case MonsterState.trace:
				nvAgent.destination = PlayerTr.position;
				nvAgent.Resume ();
				animator.SetBool("IsAttack", false);
				animator.SetBool("IsTrace", true);
				break;
			case MonsterState.attack:
				nvAgent.Stop ();
				animator.SetBool("IsAttack", true);
				break;

			}
			yield return null;
		}
	}
	void CreateBloodEffect(Vector3 pos){
		GameObject blood1 = (GameObject)Instantiate(bloodEffect, pos,Quaternion.identity);
		Destroy(blood1, 2.0f);
		Vector3 decalPos = MonsterTr.position + (Vector3.up*0.05f);
		Quaternion decalRot = Quaternion.Euler(90, 0, Random.Range(0, 360));
		GameObject blood2 = (GameObject)Instantiate(bloodDecal, decalPos, decalRot);
		float scale = Random.Range(1.5f, 1.3f);
		blood2.transform.localScale = Vector3.one*scale;
		Destroy(blood2, 0.5f);
	}

	void OnCollisionEnter(Collision coll){
       

        if (coll.gameObject.tag == "BULLET")
        {
            CreateBloodEffect(coll.transform.position);
            count++;

            ScoreManage.score += 10;

            if (count == 3)
            {
                Destroy(gameObject);
                ScoreManage.score += 10;
            }

        }


    }

    void spawn()
    {
 //       if (playerLife.currentLife <= 0) return;
        int spawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation);
    }
    
	// Update is called once per frame
	void Update () {
	
	}
}
