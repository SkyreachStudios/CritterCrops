using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    private bool status = false;

    public Plant planted = null;

    private float time = 0f;

    public Animator animator;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(planted != null)
        {

            time += Time.deltaTime;

            if (time >= 1f)
            {
                time = 0f;
                planted.plantAge++;
                //Debug.Log("Plant Age: " + planted.plantAge + "\nSapling age: " + planted.ageToSapling + "\nHarvest age: " + planted.ageToHarvest);
                if (planted.plantAge == planted.ageToSapling)
                {
                    
                    animator.SetBool("isSprout", false);
                    animator.SetBool("isSapling", true);
                }
                else if (planted.plantAge == planted.ageToHarvest)
                {
                    
                    animator.SetBool("isSapling", false);
                    animator.SetBool("isHarvest", true);
                }
            }



            
        }
        
    }



    public bool getStatus()
    {
        return this.status;
    }

    public void setStatus()
    {
        if(this.status == false)
        {
            status = true;
        }
        else
        {
            status = false;
        }
    }

    public Plant GetPlant()
    {
        return this.planted;
    }

    public void setPlant(Plant plant)
    {
        this.planted = plant;
    }

    public void setAnim(Animator anim)
    {
        this.animator = anim;
    }

}
