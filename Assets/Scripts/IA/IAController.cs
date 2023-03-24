using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum AIStateEnum
{
    None = 0,
    Idle = 1,
    Roam = 2,
    Patrol = 3,
    Salut = 4,
    Talk = 5
}

public class IAController : MoveController
{
    [Header("IAController")]

    [SerializeField]
    AIStateEnum startState = new AIStateEnum();

    [SerializeField]
    AIStateEnum currentState = new AIStateEnum();

    [SerializeField]
    AIStateEnum nextState = new AIStateEnum();

    [Serializable]
    public class StateData
    {
        public AIStateEnum State = new AIStateEnum();
        public float Duration = 1f;
    }

    [SerializeField]
    public List<StateData> StateStory = new List<StateData>();



    private void Start()
    {
        currentState = startState;
    }

    void Update()
    {
        BehavingState();

        if (CheckForTransition())
        {            
            ConditionForTransition();
            LaunchTransition();
        }
    }

    bool CheckForTransition()
    {
        switch (currentState)
        {
            case AIStateEnum.None:
           //     nextState = AIStateEnum.Idle;
           //     return true;
           //     break;
        //    case AIStateEnum.Idle:
                nextState = AIStateEnum.Roam;
                return true;
                break;
        //    case AIStateEnum.Roam:
         //       nextState = AIStateEnum.Salut;
          //      return true;
          //      break;
        //    case AIStateEnum.Salut:
        //        nextState = AIStateEnum.Talk;
        //        return true;
        //        break;
        }
        return false;
    }

    void ConditionForTransition()
    {
        Keyboard keyboard = Keyboard.current;
        switch (currentState)
        {
            case AIStateEnum.None:
                if (keyboard.tKey.wasPressedThisFrame)
                {
                    Debug.Log("AIStateEnum.None");
                    nextState = AIStateEnum.Idle;
                }
                break;
            case AIStateEnum.Idle:
                if (keyboard.mKey.wasPressedThisFrame)
                {
                    Debug.Log("AIStateEnum.Roam");
                    nextState = AIStateEnum.Roam;
                }
                if (keyboard.sKey.wasPressedThisFrame)
                {
                    Debug.Log("AIStateEnum.Salut");
                    nextState = AIStateEnum.Salut;
                }
                if (keyboard.tKey.wasPressedThisFrame)
                {

                    Debug.Log("AIStateEnum.Talk");
                    nextState = AIStateEnum.Talk;
                }
                break;
            case AIStateEnum.Roam:
                if (keyboard.sKey.wasPressedThisFrame)
                {
                    nextState = AIStateEnum.Salut;
                }
                break;
            case AIStateEnum.Patrol:
                if (keyboard.sKey.wasPressedThisFrame)
                {
                    nextState = AIStateEnum.Salut;
                }
                break;
            case AIStateEnum.Salut:
                if (keyboard.mKey.wasPressedThisFrame)
                {
                    nextState = AIStateEnum.Roam;
                }
                break;
            case AIStateEnum.Talk:
                if (keyboard.mKey.wasPressedThisFrame)
                {
                    nextState = AIStateEnum.Roam;
                }
                break;
        }
        LaunchTransition();
    }

    void LaunchTransition()
    {
        EndState();
        currentState = nextState;
        StartState();
    }

    void EndState()
    {
        switch (currentState)
        {
            case AIStateEnum.None:
                // TODO
                break;
            case AIStateEnum.Idle:
                animator.SetBool("Idle", false);
                break;
            case AIStateEnum.Roam:
                StopMoveBehaviour();
                break;
            case AIStateEnum.Patrol:
                StopMoveBehaviour();
                break;
            case AIStateEnum.Salut:
                animator.SetBool("Salut", false);
                break;
            case AIStateEnum.Talk:
                animator.SetBool("Talk", false);
                break;
        }
    }

    void StartState()
    {
        switch (currentState)
        {
            case AIStateEnum.None:
                // TODO
                break;
            case AIStateEnum.Idle:
                animator.SetBool("Idle", true);
                break;
            case AIStateEnum.Roam:
                InitMoveBehaviour();
                break;
            case AIStateEnum.Patrol:
                InitMoveBehaviour();
                break;
            case AIStateEnum.Salut:
                animator.SetBool("Salut", true);
                break;
            case AIStateEnum.Talk:
                animator.SetBool("Talk", true);
                break;
        }
    }

    private void BehavingState()
    {
        switch (currentState)
        {
            case AIStateEnum.None:
                // TODO
                break;
            case AIStateEnum.Idle:
                animator.SetBool("Idle", true);
                break;
            case AIStateEnum.Roam:
                MoveBehaviour();
                break;
            case AIStateEnum.Patrol:
                MoveBehaviour();
                break;
            case AIStateEnum.Salut:
                // TODO
                break;
            case AIStateEnum.Talk:
                // TODO
                break;
        }        
    }
}
