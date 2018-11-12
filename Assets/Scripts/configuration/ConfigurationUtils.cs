using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static ConfigurationData configurationData;
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return configurationData.PaddleMoveUnitsPerSecond; }
    }
    public static float BallImpulseForse
    {
        get { return configurationData.BallImpulseForce;}
    }
    public static float BallLifeTime
    {
        get { return configurationData.BallLifeTime;}
    }
    public static float MinSpawnTime
    {
        get { return configurationData.MinSpawnTime;}
    }
    public static float MaxSpawnTime
    {
        get { return configurationData.MaxSpawnTime;}
    }
    public static float Direction
    {
        get { return -80;}
    }
    public static int StandardBlockPoints
    {
        get { return configurationData.StandardBlockPoints;}
    }
    public static int BonusBlockPoints
    {
        get { return configurationData.BonusBlockPoints;}
    }
    public static int PickUpBlockPoints
    {
        get { return configurationData.PickUpBlockPoints;}
    }
    public static float StandardBlockProbability
    {
        get { return configurationData.StandardBlockProbability;}
    }
    public static float BonusBlockProbability
    {
        get { return configurationData.BonusBlockProbability;}
    }
    public static float PickUpBlockProbability
    {
        get { return configurationData.PickUpBlockProbability;}
    }
    public static int BallLeft
    {
        get { return configurationData.BallLeft;}
    }

    #endregion
    
    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configurationData = new ConfigurationData();
    }
}
