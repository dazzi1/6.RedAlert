using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum WeaponType {
    Gun = 0,
    Rifle = 1,
    Rocket = 2,
    MAX
}

public abstract class IWeapon
{

    //protected int mAtkPlusValue;
    protected WeaponBaseAttr mBaseAttr;

    protected GameObject mGameObject;
    protected ParticleSystem mPariticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;

    protected ICharacter mOwner;
    protected float mEffectDisplayTime = 0;

    public float atkRange {
        get { return mBaseAttr.atkRange; }
    }
    public int atk {
        get { return mBaseAttr.atk; }
    }
    public ICharacter owner {
        set { mOwner = value; }
    }
    public GameObject gameObject {
        get { return mGameObject; }
    }

    public IWeapon(WeaponBaseAttr baseAttr, GameObject gameObject) {
        mBaseAttr = baseAttr;
        mGameObject = gameObject;

        Transform effect = mGameObject.transform.Find("Effect");
        mPariticle = effect.GetComponent<ParticleSystem>();
        mLine = effect.GetComponent<LineRenderer>();
        mLight = effect.GetComponent<Light>();
        mAudio = effect.GetComponent<AudioSource>();
    }

    public void Update() {
        if (mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime <= 0)
            {
                DisableEffect();
            }
        }
    }

    //7.模板方法模式
    public void Fire(Vector3 targetPosition) {

        PlayMuzzleEffect();

        PlayBulletEffect(targetPosition);

        //设置特效显示时间
        SetEffectDisplayTime();

        PlaySound();
    }

    protected abstract void SetEffectDisplayTime();

    //显示枪口特效
    protected virtual void PlayMuzzleEffect() {
        mPariticle.Stop();
        mPariticle.Play();
        mLight.enabled = true;
    }

    //显示子弹轨迹特效
    protected abstract void PlayBulletEffect(Vector3 targetPosition);

    protected void DoPlayBulletEffect(float width, Vector3 targetPosition) {
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPosition);
    }

    //播放声音
    protected abstract void PlaySound();

    protected void DoPlaySound(string clipName) {
        AudioClip clip = FactoryManager.assetFactory.LoadAudioClip(clipName);
        mAudio.clip = clip;
        mAudio.Play();
    }

    private void DisableEffect() {
        mLine.enabled = false;
        mLight.enabled = false;
    }
}

