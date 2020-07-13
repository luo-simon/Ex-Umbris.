using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;

    public Animator anim;

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        anim.SetFloat("Speed", aiPath.desiredVelocity.magnitude);
        anim.SetFloat("Vertical", aiPath.desiredVelocity.y);
        
        if (aiPath.desiredVelocity.magnitude > 0)
        {
            anim.SetFloat("LookDirection", Vector2.SignedAngle(Vector2.right, aiPath.desiredVelocity));
        }
        
    }
}
