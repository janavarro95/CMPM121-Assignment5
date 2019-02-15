using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedDoors : MonoBehaviour
{

    public static float DoorSpeed = .1f;

    public bool neg;

    public enum Direction
    {
        x,
        y,
        z
    }


    public Direction moveDirection;
    public float speed;
    public bool finished
    {
        get
        {
            return this.distanceTravled >= targetDistance;
        }
    }

    public float distanceTravled;
    public float targetDistance;

    private Vector3 oldPos;

    public float lerpAmount
    {
        get
        {
            return distanceTravled / targetDistance;
        }
    }

    public int collectablesNeeded;



    public bool IsActive
    {
        get
        {
            return Collectable.CollectablesCollected >= collectablesNeeded;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        oldPos = this.gameObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished) return;
        if (IsActive)
        {
            if (speed > 0)
            {
                this.distanceTravled += speed;
            }
            else
            {
                this.distanceTravled += DoorSpeed;
            }
            if (moveDirection == Direction.x)
            {
                Vector3 offset = neg ? new Vector3(-targetDistance, 0, 0) : new Vector3(targetDistance, 0, 0);

                this.gameObject.transform.localPosition = Vector3.Lerp(oldPos, oldPos + offset, lerpAmount);
            }

            if (moveDirection == Direction.y)
            {
                Vector3 offset = neg ? new Vector3(0, -targetDistance, 0) : new Vector3(0, targetDistance, 0);

                this.gameObject.transform.localPosition = Vector3.Lerp(oldPos, oldPos + offset, lerpAmount);
            }

            if (moveDirection == Direction.z)
            {
                Vector3 offset = neg ? new Vector3(0, 0, -targetDistance) : new Vector3(0, 0, targetDistance);

                this.gameObject.transform.localPosition = Vector3.Lerp(oldPos, oldPos + offset, lerpAmount);
            }
        }

    }
}
