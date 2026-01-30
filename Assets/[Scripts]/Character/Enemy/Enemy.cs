using UnityEngine;

public class Enemy : Character
{
    private bool isSeen;
    private float baseSpeed;
    protected override void Awake()
    {
        base.Awake();
        baseSpeed = MoveSpeed;
    }

    void Update()
    {
        if (isSeen)
        {
            MoveSpeed = 0;
        }
        else
        {
            MoveSpeed = baseSpeed;
        }
    }

    public bool IsSeen
    {
        get
        {
            return isSeen;
        }
        set
        {
            isSeen = value;
        }
    }
}
