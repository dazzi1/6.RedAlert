using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DM08ChainOfResponsibility : MonoBehaviour {

	void Start () {
		char problem = 'c';
		DMHandlerA handlerA = new DMHandlerA();
		DMHandlerB handlerB = new DMHandlerB();
		DMHandlerC handlerC = new DMHandlerC();
		handlerA.SetNextHandler(handlerB)
			.SetNextHandler(handlerC);

		handlerA.Handle(problem);
	}
	
	void Update () {
		
	}
}

public abstract class IDMHandler {
	protected IDMHandler mNextHandler = null;
	public IDMHandler nextHandler {
		set { mNextHandler = value; }
	}
	public IDMHandler SetNextHandler(IDMHandler handler) {
		mNextHandler = handler;
		return mNextHandler;
	}
	public virtual void Handle(char problem) { }
}

class DMHandlerA:IDMHandler {
	public override void Handle(char problem) {
        if (problem == 'a')
        {
			Debug.Log("处理完了A问题");
        }
        else
        {
            if (mNextHandler != null)
            {
				mNextHandler.Handle(problem);
            }
        }
	}
}

class DMHandlerB : IDMHandler
{
	public override void Handle(char problem)
	{
		if (problem == 'b')
		{
			Debug.Log("处理完了B问题");
		}
		else
		{
			if (mNextHandler != null)
			{
				mNextHandler.Handle(problem);
			}
		}
		
	}
}

class DMHandlerC : IDMHandler
{
	public override void Handle(char problem)
	{
		if (problem == 'c')
		{
			Debug.Log("处理完了c问题");
		}
		else
		{
			if (mNextHandler != null)
			{
				mNextHandler.Handle(problem);
			}
		}

	}
}


