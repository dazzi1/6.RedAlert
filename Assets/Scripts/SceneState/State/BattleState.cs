using System;
using System.Collections.Generic;
using System.Text;


class BattleState : ISceneState
{
    public BattleState(SceneStateController controller) : base("03BattleScene", controller) { }

    //兵营 关卡 角色管理 行动力 成就系统..
    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }
    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }
    public override void StateUpdate()
    {
        if (GameFacade.Instance.isGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }
        GameFacade.Instance.Update();
    }
}

