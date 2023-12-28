using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

//1.状态模式
public class SceneStateController
{
    private ISceneState mState;

    private AsyncOperation mAO;

    private bool mIsRunStart = false;

    public void SetState(ISceneState state,bool isLoadScene = true) {
        if (mState != null)
        {
            //让上一个场景状态做一下清理工作
            mState.StateEnd();
        }
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        }
        else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
    }

    public void StateUpdate() {
        if (mAO!=null&&mAO.isDone == false)
        {
            return;
        }

        if (mIsRunStart == false && mAO!=null && mAO.isDone == true)
        {
            mState.StateStart();
            mIsRunStart = true;
        }

        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}

