using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform ani_Attack_barrel;
    public Transform ani_Shot_attack;

    public float power;
    public bool ispowering=false;
    public bool canattack = false;
    public float timer_attack = 0;
    public float angle;
    public bool isAttack=false;
    public float couter = 0;
   
    public float time_Reset=30; 
    public float count_time_Reset=0;

    public void Start()
    {
        ani_Attack_barrel = PlayerController.instance.playerAttack.Find("Attack_barrel");
        ani_Shot_attack = PlayerController.instance.playerAttack.Find("Attack_barrel").Find("Shot_Attack");
       
    }
    // Update is called once per frame
    float rotationSpeed = 45;
    public Vector3 currentEulerAngles;
    public Quaternion currentRotation;
 
    public float z;
    void Update()
    {


        AttackDelay();
        Rotation_Barrel();
        if (this.Lst_turn()&&!ispowering)
            Finish_Attack();
  

    }
    protected virtual void Rotation_Barrel()
    {

        //modifying the Vector3, based on input multiplied by speed and time


        if (Input.GetKey(KeyCode.UpArrow))
        {
            z += Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            z -= Time.deltaTime;
        }
        else
        {
            z = 0;
        }
        
        currentEulerAngles += new Vector3(0, 0, z) * Time.deltaTime * rotationSpeed;

        //moving the value of the Vector3 into Quanternion.eulerAngle format
        currentRotation.eulerAngles = currentEulerAngles;

        //apply the Quaternion.eulerAngles change to the gameObject
        ani_Attack_barrel.rotation = currentRotation;
       
          //  z = 0;


    }
    protected virtual void AttackDelay()
    {
        timer_attack += Time.deltaTime;
        if (timer_attack > 3)
        {
            canattack = true;
        }
        if (canattack == true)
        { 
            Attack(); 
        
        }
        
            
    }
    protected virtual void Attack()
    {
        if (Input.GetButton("Jump")&&canattack)
        {
            ispowering = true;

            if (power < 100 && ispowering)
            {
                power += (10 * Time.deltaTime);
                //Debug.Log("Power" + power);
            }
           
        }
        else if (!Input.GetButton("Jump")&&ispowering)
        {
            Attacking();
        }
    }
    
    protected virtual void Attacking() //dien ani
    {
        
        couter += Time.deltaTime;
        Animation_attack_Barrel_true();
        if (couter >= 1)
        {
            Animation_attack_Barrel_false();
            Finish_Attack();
        }


    }
    
      protected virtual void Animation_attack_Barrel_true()
      {
              ani_Attack_barrel.GetComponent<Animator>().enabled = true;
              ani_Shot_attack.GetComponent<Animator>().enabled = true; 
              ani_Shot_attack.GetComponent<Renderer>().enabled = true;
      }
    protected virtual void Animation_attack_Barrel_false()
      {
              ani_Attack_barrel.GetComponent<Animator>().enabled = false;
              ani_Shot_attack.GetComponent<Animator>().enabled = false;

              ani_Shot_attack.GetComponent<Renderer>().enabled = false;
        
      }
      protected virtual void Finish_Attack()//reset
      {
        //this.canattack = true;
        this.timer_attack = 0;
        this.ispowering = false;
        this.canattack= false; 
        this.power = 0;
        this.couter = 0;
        this.count_time_Reset = 0;


      }
    public virtual bool Lst_turn()
    {
        count_time_Reset += Time.deltaTime;
        
        return count_time_Reset > time_Reset ? true:false;
    }
      
       

  
}
