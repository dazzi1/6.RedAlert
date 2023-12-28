using System;
using System.Collections.Generic;
using System.Text;

public class ISceneState
{
    private string mSceneName;
    protected SceneStateController mController;

    public ISceneState(string mSceneName, SceneStateController mController)
    {
        this.mSceneName = mSceneName;
        this.mController = mController;
    }

    public string SceneName {
        get { return mSceneName; }
    }
    //每次进入到这个状态的时候调用
    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
}

