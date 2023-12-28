using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//2.对于状态管理是 外观模式 
//4.对于子系统之间 中介者模式
public class GameFacade
{
    private static GameFacade _instance = new GameFacade();
    
    private bool mIsGameOver = false;

    //3.单例模式
    public static GameFacade Instance { get { return _instance; } }
        
    public bool isGameOver { get { return mIsGameOver; } }

    private GameFacade() { }

    private AchievementSystem mAchievementSystem;
    private CampSystem mCampSystem;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;

    private CampInfoUI mCampInfoUI;
    private GamePauseUI mGamePauseUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    public void Init() {
        mAchievementSystem = new AchievementSystem();
        mCampSystem = new CampSystem();
        mCharacterSystem = new CharacterSystem();
        mEnergySystem = new EnergySystem();
        mGameEventSystem = new GameEventSystem();
        mStageSystem = new StageSystem();

        mCampInfoUI = new CampInfoUI();
        mGamePauseUI = new GamePauseUI();
        mGameStateInfoUI = new GameStateInfoUI();
        mSoldierInfoUI = new SoldierInfoUI();

        mAchievementSystem.Init();
        mCampSystem.Init();
        mCharacterSystem.Init();
        mEnergySystem.Init();
        mGameEventSystem.Init();
        mStageSystem.Init();

        mCampInfoUI.Init();
        mGamePauseUI.Init();
        mGameStateInfoUI.Init();
        mSoldierInfoUI.Init();

        LoadMemento();
    }
    public void Update() {
        mAchievementSystem.Update();
        mCampSystem.Update();
        mCharacterSystem.Update();
        mEnergySystem.Update();
        mGameEventSystem.Update();
        mStageSystem.Update();

        mCampInfoUI.Update();
        mGamePauseUI.Update();
        mGameStateInfoUI.Update();
        mSoldierInfoUI.Update();
    }
    public void Release() {
        mAchievementSystem.Release();
        mCampSystem.Release();
        mCharacterSystem.Release();
        mEnergySystem.Release();
        mGameEventSystem.Release();
        mStageSystem.Release();

        mCampInfoUI.Release();
        mGamePauseUI.Release();
        mGameStateInfoUI.Release();
        mSoldierInfoUI.Release();

        CreateMemento();
    }

    public Vector3 GetEnemyTargetPosition() {
        return mStageSystem.targetPosition;
    
    }

    public void ShowCampInfo(ICamp camp) {
        mCampInfoUI.ShowCampInfo(camp);
    }

    public void AddSoldier(ISoldier soldier) {
        mCharacterSystem.AddSoldier(soldier);
    }
    public void AddEnemy(IEnemy enemy) {
        mCharacterSystem.AddEnemy(enemy);
    }
    public void RemoveEnemy(IEnemy enemy) {
        mCharacterSystem.RemoveEnemy(enemy);
    }

    public bool TakeEnergy(int value) {
        return mEnergySystem.TakeEnergy(value);
    }
    public void RecycleEnergy(int value)
    {
        mEnergySystem.RecycleEnergy(value);
    }
    public void ShowMsg(string msg) {
        mGameStateInfoUI.ShowMsg(msg);
    }

    public void UpdateEnergySlider(int nowEnergy, int maxEnergy) {
        mGameStateInfoUI.UpdateEnergySlider(nowEnergy, maxEnergy);
    }

    public void RegisterObserver(GameEventType eventType, IGameEventObserver observer) {
        mGameEventSystem.RegisterObserver(eventType, observer);
    }

    public void RemoveObserver(GameEventType eventType, IGameEventObserver observer) {
        mGameEventSystem.RemoveObserver(eventType, observer);
    }

    public void NotifySubject(GameEventType eventType) {
        mGameEventSystem.NotifySubject(eventType);
    }

    private void LoadMemento() {
        AchievementMemento memento = new AchievementMemento();
        memento.LoadData();
        mAchievementSystem.SetMemento(memento);
    }

    private void CreateMemento() {
        AchievementMemento memento = mAchievementSystem.CreateMemento();
        memento.SaveData();
    }

    public void RunVisitor(ICharacterVisitor visitor) {
        mCharacterSystem.RunVisitor(visitor);
    }
}

