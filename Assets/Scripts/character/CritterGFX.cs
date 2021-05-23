using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CritterGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Animator anim;

    Vector2 movement;
    // Update is called once per frame
    private void Update()
    {
        movement.x = aiPath.desiredVelocity.x;
        movement.y = aiPath.desiredVelocity.y;


        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        //moving right
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            anim.SetBool("facingRight?", true);

        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            anim.SetBool("facingRight?", false);
        }
    }
}
