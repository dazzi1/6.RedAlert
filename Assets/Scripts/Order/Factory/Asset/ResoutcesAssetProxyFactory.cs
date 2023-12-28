using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class ResoutcesAssetProxyFactory : IAssetFactory
{
    private ResourcesAssetFactory mAssetFactory = new ResourcesAssetFactory();
    private Dictionary<string, GameObject> mSoldiers = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEnemys = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mWeapons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> mEffects = new Dictionary<string, GameObject>();
    private Dictionary<string, AudioClip> mAudioClips = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> mSprites = new Dictionary<string, Sprite>();

    public GameObject LoadEffect(string name)
    {
        return LoadDic(mEffects, ResourcesAssetFactory.EffectPath, name);
    }

    public GameObject LoadEnemy(string name)
    {
        return LoadDic(mEnemys, ResourcesAssetFactory.EnemyPath, name);
    }

    public GameObject LoadSoldier(string name)
    {
        return LoadDic(mSoldiers, ResourcesAssetFactory.SoldierPath, name);
    }

    public GameObject LoadWeapon(string name)
    {
        return LoadDic(mWeapons, ResourcesAssetFactory.WeaponPath, name);
    }

    public Sprite LoadSprite(string name)
    {
        if (mSprites.ContainsKey(name))
        {
            return mSprites[name];
        }
        else
        {
            Sprite sprite = mAssetFactory.LoadSprite(name);
            mSprites.Add(name, sprite);
            return sprite;
        }
    }

    public AudioClip LoadAudioClip(string name)
    {
        if (mAudioClips.ContainsKey(name))
        {
            return mAudioClips[name];
        }
        else {
            AudioClip audio = mAssetFactory.LoadAudioClip(name);
            mAudioClips.Add(name, audio);
            return audio;
        }
    }

    public GameObject LoadDic(Dictionary<string, GameObject> mDic, string path,string name) {
        if (mDic.ContainsKey(name))
        {
            return GameObject.Instantiate(mDic[name]);
        }
        else
        {
            GameObject asset = mAssetFactory.LoadAsset(path + name) as GameObject;
            mDic.Add(name, asset);
            return GameObject.Instantiate(asset);
        }
    }
}

