using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[Serializable]
public class SaveData
{
    [Header("Main parametrs")]
    [ReadOnly] public int Coins = 200;
    //[ReadOnly] public string LastCoinCollect = DateTime.UtcNow.ToString();//����
    //[field: SerializeField, ReadOnly] public int LevelReached { get; set; } = 0;
    //[field: SerializeField, ReadOnly] public int MaxLevelReached { get; set; } = 0;
    //[field: SerializeField, ReadOnly] public int LevelPlaying { get; set; } = 1;
    //[ReadOnly] public bool HasSound = true;
    //[ReadOnly] public bool HasMusic = true;
    //[ReadOnly] public bool FirstOpenApp = false;


    //[Header("Tutorial")]
    //[ReadOnly] public bool IsMineBought = false;
    //[ReadOnly] public bool IsMagicTowerBought = false;
    //[ReadOnly] public bool IsFortressUpgraded = false;
    //[field: SerializeField, ReadOnly] public bool TutorialChestCollected { get; set; }
    //[field: SerializeField, ReadOnly] public bool IsBarrackBought { get; set; }

    //[field: SerializeField, ReadOnly] public int LastTutorialStep { get; set; } = -1;
    //[field: SerializeField, ReadOnly] public List<int> FinishedOncallSteps { get; set; } = new();    
    //[field: SerializeField, ReadOnly] public List<int> DoneEasySteps { get; set; } = new();
    //[field: SerializeField, ReadOnly] public bool IsTutorialCompleted { get; set; }


    //[Header("Buildings")]
    //[ReadOnly] public int ArcheryCurrentLevel = 1;
    //[ReadOnly] public int BarracksCurrentLevel = 1;
    //[ReadOnly] public int FortressCurrentLevel = 1;
    //[ReadOnly] public int MineCurrentLevel = 1;

    //[Header("Gold Storage")]
    //[ReadOnly] public int CurrentBarAmount;
    //[ReadOnly] public int CurrentBarLimit;
    //[ReadOnly] public int CurrentLevelGoldStorageIndex;
    //[ReadOnly] public bool PlayerGetFirstCollectCoin = false;

    //[Header("Player Lives")]
    //[ReadOnly] public int SimpleRestartLevel = 1;
    //[ReadOnly] public int LivesLeft = 5;
    //[ReadOnly] public int MaxLives = 5;

    //[Header("Magic Tower")]
    //[ReadOnly] public int LastUnlockedAbility = 1;
    //[ReadOnly] public int OpenAbilitySots = 3;
    //[ReadOnly] public int Gems = 0;
    //[ReadOnly] public List<string> ActivatedAbilities = new();
    //[Header("Magic Tower Level Ability")]
    //[ReadOnly] public int CurrentLevelBoulder = 1;
    //[ReadOnly] public int CurrentLevelFireBall = 1;
    //[ReadOnly] public int CurrentLevelWave = 1;

    //[ReadOnly] public int CurrentLevelHorh = 1;
    //[ReadOnly] public int CurrentLevelIce = 1;
    //[ReadOnly] public int CurrentLevelLighting = 1;

    //[ReadOnly] public int CurrentLevelPoison = 1;
    //[ReadOnly] public int CurrentLevelStopTime = 1;
    //[ReadOnly] public int CurrentLevelWall = 1;

    //[Header("LootBoxes")]
    //[ReadOnly] public int LootRewardCount = 0;
    //[ReadOnly] public int GemsReceiveCount = 0;
    //[ReadOnly] public int BoostReceiveCount = 0;
    //[field: SerializeField, ReadOnly] public bool KeyReceived { get; set; } = false;
    //[ReadOnly] public int KeysCurrentProbability = 100;
    //[ReadOnly] public int Keys = 0;
    //[ReadOnly] public int Spearman_Hero_Count = 0;
    //[ReadOnly] public int Swordsman_Hero_Count = 0;
    //[ReadOnly] public int Wizard_Hero_Count = 0;
    //[ReadOnly] public int Spearsman_DrawnCount = 0;
    //[ReadOnly] public int Swordsman_DrawnCount = 0;
    //[ReadOnly] public int Wizard_DrawnCount = 0;

    //[Header("Monetization")]
    //[ReadOnly] public bool OfferTimeUp;
    //[ReadOnly] public string OfferEndTime = DateTime.UtcNow.ToString();//"13.03.2000 20:27:54";//����
    //[field: SerializeField, ReadOnly] public bool RemoveAds { get; set; } = false;
    //[ReadOnly] public int ItemDoubleArrow = 3;
    //[ReadOnly] public int ItemTripleArrow = 1;
    //[ReadOnly] public int ItemPoison = 3;
    //[ReadOnly] public int ItemFreeze = 3;
    //[ReadOnly] public bool IsX2Restart;
    //[ReadOnly] public bool IsCastleStart;
    //[ReadOnly] public bool StarterPackBought;

    //[Header("Tavern")]
    //[ReadOnly] public int FreeCoins;
    //[ReadOnly] public int FreeGems;
    //[ReadOnly] public int FreeKeys;
    //[ReadOnly] public int CurrentFreeDoubleDraws;
    //[ReadOnly] public bool RestrictionON;
    //[ReadOnly] public string RestrictionEndTime = DateTime.UtcNow.ToString();

    //[Header("Daily reward")]
    //[ReadOnly] public int LastDayGetReward;
    //[ReadOnly] public string DataGetLastReward = DateTime.Now.ToString();
    //[ReadOnly] public bool PlayerCancelGetReward = false;


    //[Header("Other")]
    //[ReadOnly] public bool FirstLeve2KnightSet = false;
    //[field: SerializeField, ReadOnly] public int MobChestSlots { get; set; } = 0;
    //[field: SerializeField, ReadOnly] public int ChestsCollected { get; set; }
    //[ReadOnly] public bool IsFeedbackShown = false;
    //[ReadOnly] public int StatisticsMaxKnight;
    //[ReadOnly] public int LevelStars; // ���� ����� �� ������������ ����� � ����� LevelStar(int level, int stars)
    //[field: SerializeField, ReadOnly] public int LastTaskConnectionLevel { get; set; }
    //[ReadOnly] public string EnergySubscriptionEndsDate = DateTime.UtcNow.ToString();// "13.03.2000 20:27:54";//����
}