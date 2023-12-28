using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM01State : MonoBehaviour {
    void Start() {

        Context context = new Context();

        context.SetState(new ConcreteStateA(context));

        context.Handle(5);
        context.Handle(20);
        context.Handle(30);
        context.Handle(1);
        context.Handle(6);
    }
}

public class Context {

    private IState mState;

    public void SetState(IState state) {
        mState = state;
    }

    public void Handle(int arg) {
        mState.Handle(arg);
    }
}

public interface IState {
    void Handle(int arg);
}

public class ConcreteStateA : IState
{
    private Context mContext;

    public ConcreteStateA(Context context) {
        mContext = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreateStateA.Handle " + arg);
        if (arg> 10)
        {
            //切换状态
            mContext.SetState(new ConcreteStateB(mContext));
        }
    }
}

public class ConcreteStateB : IState
{
    private Context mContext;

    public ConcreteStateB(Context context)
    {
        mContext = context;
    }

    public void Handle(int arg)
    {
        Debug.Log("ConcreateStateB.Handle " + arg);
        if (arg<=10)
        {
            //切换状态
            mContext.SetState(new ConcreteStateA(mContext));
        }
    }
}
