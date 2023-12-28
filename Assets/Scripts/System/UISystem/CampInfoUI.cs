using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CampInfoUI:IBaseUI
{
    private Image mCampIcon;
    private Text mCampName;
    private Text mCampLevel;
    private Text mWeaponLevel;
    private Button mCampUpgradeBtn;
    private Button mWeaponUpgradeBtn;
    private Button mTrainBtn;
    private Text mTrainBtnText;
    private Button mCancelTrainBtn;
    private Text mAliveCount;
    private Text mTrainingCount;
    private Text mTrainTime;

    private ICamp mCamp;

    public override void Init() {
        base.Init();
        GameObject canvas = GameObject.Find("Canvas");
        mRootUI = UnityTool.FindChild(canvas, "CampInfoUI");

        mCampIcon = UITool.FindChild<Image>(mRootUI, "CampIcon");
        mCampName = UITool.FindChild<Text>(mRootUI, "CampName");
        mCampLevel = UITool.FindChild<Text>(mRootUI, "CampLv");
        mWeaponLevel = UITool.FindChild<Text>(mRootUI, "WeaponLv");
        mCampUpgradeBtn = UITool.FindChild<Button>(mRootUI, "CampUpgradeBtn");
        mWeaponUpgradeBtn = UITool.FindChild<Button>(mRootUI, "WeaponUpgradeBtn");
        mTrainBtn = UITool.FindChild<Button>(mRootUI, "TrainBtn");
        mTrainBtnText = UITool.FindChild<Text>(mRootUI, "TrainBtnText");
        mCancelTrainBtn = UITool.FindChild<Button>(mRootUI, "CancelTrainBtn");
        mAliveCount = UITool.FindChild<Text>(mRootUI, "AliveCount");
        mTrainingCount = UITool.FindChild<Text>(mRootUI, "TrainingCount");
        mTrainTime = UITool.FindChild<Text>(mRootUI, "TrainTime");

        mTrainBtn.onClick.AddListener(OnTrainClick);
        mCancelTrainBtn.onClick.AddListener(OnCancelTrainClick);
        mCampUpgradeBtn.onClick.AddListener(OnCampUpgradeClick);
        mWeaponUpgradeBtn.onClick.AddListener(OnWeaponUpgradeClick);

        Hide();
    }

    public override void Update()
    {
        base.Update();
        if (mCamp!=null)
        {
            ShowTrainingInfo();
        }
    }

    public void ShowCampInfo(ICamp camp) {

        Show();
        mCamp = camp;

        mCampIcon.sprite = FactoryManager.assetFactory.LoadSprite(camp.iconSprite);
        mCampName.text = camp.name;
        mCampLevel.text = camp.lv.ToString();
        ShowWeaponLevel(camp.weaponType);
        mTrainBtnText.text = "训练\n" + mCamp.energyCostTrain + "点能量";
        ShowTrainingInfo();
    }
    private void ShowTrainingInfo() {
        mTrainingCount.text = mCamp.trainCount.ToString();
        mTrainTime.text = mCamp.trainRemainingTime.ToString("0.00");
        if (mCamp.trainCount == 0)
        {
            mCancelTrainBtn.interactable = false;
        }
        else
        {
            mCancelTrainBtn.interactable = true;
        }
    }
    void ShowWeaponLevel(WeaponType weaponType) {
        switch (weaponType)
        {
            case WeaponType.Gun:
                mWeaponLevel.text = "短枪";
                break;
            case WeaponType.Rifle:
                mWeaponLevel.text = "长枪";
                break;
            case WeaponType.Rocket:
                mWeaponLevel.text = "火箭";
                break;
            case WeaponType.MAX:
                break;
            default:
                break;
        }
    }

    private void OnTrainClick() {
        int energy = mCamp.energyCostTrain;
        if (GameFacade.Instance.TakeEnergy(energy))
        {
            mCamp.Train();
        }
        else
        {
            GameFacade.Instance.ShowMsg("训练士兵需要能量" + energy + "，能量不足，无法训练新的士兵");
        }
        
    }
    private void OnCancelTrainClick() {
        mFacade.RecycleEnergy(mCamp.energyCostTrain);
        mCamp.CancelTrainCommand();
    }
    private void OnCampUpgradeClick() {
        int energy = mCamp.energyCostCampUpgrade;
        if (energy < 0)
        {
            mFacade.ShowMsg("兵营已到最大等级，无法再进行升级");
            return;
        }
        if (mFacade.TakeEnergy(energy)) {
            mCamp.UpgradeCamp();
            ShowCampInfo(mCamp);
        }
        else
        {
            mFacade.ShowMsg("升级兵营需要能量"+ energy +"，能量不足，请稍后再进行升级");
        }
    }
    private void OnWeaponUpgradeClick() {
        int energy = mCamp.energyCostWeaponUpgrade;
        if (energy<0)
        {
            mFacade.ShowMsg("武器已到最大等级，无法再进行升级");
            return;
        }
        if (mFacade.TakeEnergy(energy))
        {
            mCamp.UpgradeWeapon();
            ShowCampInfo(mCamp);
        }
        else
        {
            mFacade.ShowMsg("升级武器需要能量" + energy+"，能量不足，请稍后再进行升级");
        }
    }
}

