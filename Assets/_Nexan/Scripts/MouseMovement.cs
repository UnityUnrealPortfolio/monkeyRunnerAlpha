using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{



    [SerializeField] float m_MoveSpeed;
    [SerializeField] Transform leftPos, rightPos, middlePos;
    [SerializeField] private float m_interpolateAmount;

    [SerializeField] int m_SwipeCounter;
    [SerializeField] int maxLeftSwipeCounter,maxRightSwipeCounter;
    private void Update()
    {
        MoveForward();
        DetectSwipe();
        ChangeLanes();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * m_MoveSpeed * Time.deltaTime);
    }

    private void ChangeLanes()
    {
        Vector3 targetPos;
        switch (m_SwipeCounter)
        {
            case 0:

                targetPos = new Vector3(middlePos.position.x,transform.position.y,transform.position.z);

                transform.position = Vector3.Lerp(transform.position, targetPos, m_interpolateAmount);
                //m_CurrentLane = Lanes.LEFT;
                break;
            case 1:

                targetPos = new Vector3(rightPos.position.x, transform.position.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position,targetPos, m_interpolateAmount);
                //m_CurrentLane = Lanes.LEFT;
                break;
            case -1:
                targetPos = new Vector3(leftPos.position.x, transform.position.y, transform.position.z);

                transform.position = Vector3.Lerp(transform.position, targetPos, m_interpolateAmount);
                //m_CurrentLane = Lanes.LEFT;
                break;

        }
    }

    private void DetectSwipe()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))//when i left swipe
        {
            m_SwipeCounter--;
            if (m_SwipeCounter <= maxLeftSwipeCounter)
            {
                m_SwipeCounter = maxLeftSwipeCounter;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_SwipeCounter++;
            if (m_SwipeCounter >= maxRightSwipeCounter)
            {
                m_SwipeCounter = maxRightSwipeCounter;
            }
        }
    }
}
public enum Lanes
{
    MIDDLE,
    LEFT,
    RIGHT
}
