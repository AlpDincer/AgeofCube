using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeBowPlayer1 : MonoBehaviour
{
    private List<float> CollisionsThisStep = new List<float>(); //at each step stores collision relative positions

    private Slider sliderHealth;

    public LayerMask isEnemy;
    public LayerMask isEnemyBase;
    public Transform attackPos;

    private float attackInterval;
    public float startAttackInterval;
    public float attackRange;
    public int health;
    public int maxhealth;
    public int damage;
    public float moveSpeed;
    public int count;
    public bool multiShot = false; // Possible Upgrade, Default = false

    public GameObject healthCanvas;
    public Collider[] hitEnemy;

    void Start()
    {
        //health = 100;
        //maxhealth = 100;
        
        sliderHealth = GameObject.Find("CubeBowPlayer1HealthBar" + count.ToString()).GetComponent<Slider>(); //set initial slider value
        healthCanvas = GameObject.Find("CubeBowPlayer1HealthCanvas" + count.ToString());
        
        healthCanvas.SetActive(false);

        sliderHealth.maxValue = maxhealth;
        sliderHealth.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed; //start moving

        hitEnemy = Physics.OverlapSphere(attackPos.position, attackRange, isEnemy);//hitbox

        if (health <= 0) { Destroy(gameObject); }

        if (hitEnemy.Length > 0) // new version with error, check no collision no target movement
        {
            if (attackInterval <= 0)
            {
                //start attack

                for (int i = 0; i < hitEnemy.Length; i++)
                {
                    moveSpeed = 0;

                    if (multiShot == false)
                    { hitEnemy[0].BroadcastMessage("TakeDamage", damage); } //using hitEnemy[i] gives multishot ability

                    else { hitEnemy[i].BroadcastMessage("TakeDamage", damage); }

                    attackInterval = startAttackInterval;
                }
            }

            else
            {
                attackInterval -= Time.deltaTime;
            }
        }

        else if (hitEnemy.Length <= 0 && CollisionsThisStep.Count <= 0) { moveSpeed = 100; }

        //if (attackInterval <= 0) //Same attack code for enemy base
        //{
        //    //start attack
        //    Collider2D[] hitEnemyBase = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isEnemyBase);
        //    for (int i = 0; i < hitEnemyBase.Length; i++)
        //    {
        //        moveSpeed = 0;
        //        hitEnemyBase[i].GetComponent<BlueBaseHealth>().TakeDamage(damage);


        //        if (hitEnemyBase[i].GetComponent<BlueBaseHealth>().health <= 0)
        //        {
        //            moveSpeed = 1;
        //        }

        //    }

        //    attackInterval = startAttackInterval;
        //}
        //else
        //{
        //    attackInterval -= Time.deltaTime;
        //}

    }

    private void FixedUpdate()
    {
        if (CollisionsThisStep.Count == 1)
        {
            //Debug.Log(gameObject.name + " " + CollisionsThisStep[0]);
            if (CollisionsThisStep[0] <= 0 && hitEnemy.Length < 1) { moveSpeed = 100; }

            else { moveSpeed = 0; }
        }

        if (CollisionsThisStep.Count == 2)
        {
            moveSpeed = 0;
        }
        CollisionsThisStep.Clear();
    }

    void OnDrawGizmosSelected() //to see attack range in editor
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void OnTriggerEnter(Collider col) //on collision stop movement
    {
        Vector3 relativePosition = transform.InverseTransformPoint(col.transform.position);

        //if (relativePosition.z < 0 && col.gameObject.tag != "Terrain")
        //{ moveSpeed = 0;}
        //else { }

        if (relativePosition.z >= 0 && col.gameObject.tag != "Terrain") { moveSpeed = 0; }
    }

    void OnTriggerStay(Collider col)
    {
        float relativePosition = col.transform.position.z - gameObject.transform.position.z;

        CollisionsThisStep.Add(relativePosition);
    }

    void OnTriggerExit(Collider col) //once collision ends continue movement
    {
        if (col.gameObject.tag != "Terrain") { moveSpeed = 100; }
    }

    public void TakeDamage(int damageTaken)
    {
        healthCanvas.SetActive(true);

        health -= damageTaken;
     
        sliderHealth.value = health;
    }

    public void GetUpgrade(int multiplier) // recalculate stats after upgrade button is pressed
    {
        maxhealth = maxhealth * multiplier;
        health = maxhealth;
        damage = damage * multiplier;

        if (count > 0)
        {
            sliderHealth.maxValue = maxhealth;
            sliderHealth.value = health;
        }
    }

    public void GetMultishot()
    {
            multiShot = true;
            //Debug.Log("GetMultiShotCalled");
    }
}



