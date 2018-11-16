using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 0.3f;
    static float ballImpulseForce = 200;
    static float ballLifeTime = 12;
    static float minSpawnTime = 5;
    static float maxSpawnTime = 10;
    static int standardBlockPoints = 5;
    static float standardBlockProbability = 0.7f;
    static int bonusBlockPoints = 25;
    static float bonusBlockProbability = 0.2f;
    static int pickUpBlockPoints = 5;
    static float pickUpBlockProbability = 0.1f;
    static int ballLeft = 5;
    static int directionOffset = 30;
    static int freezeDuration = 2;
    static int speedUpDuration = 2;
    static float speedUpFactor = 1.3f;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }
    public float BallLifeTime
    {
        get { return ballLifeTime;}
    }
    public float MinSpawnTime
    {
        get {return minSpawnTime;}
    }
    public float MaxSpawnTime
    {
        get {return maxSpawnTime;}
    }
    public int StandardBlockPoints
    {
        get { return standardBlockPoints;}
    }
    public int BonusBlockPoints
    {
        get {return bonusBlockPoints;}
    }
    public int PickUpBlockPoints
    {
        get { return pickUpBlockPoints;}
    }
    public float StandardBlockProbability
    {
        get { return standardBlockProbability;}
    }
    public float BonusBlockProbability
    {
        get { return bonusBlockProbability;}
    }
    public float PickUpBlockProbability
    {
        get { return pickUpBlockProbability;}
    }
    public int BallLeft
    {
        get { return ballLeft;}
    }
    public int DirectionOffSet
    {
        get { return directionOffset;}
    }
    public int FreezeDuration
    {
        get { return freezeDuration;}
    }
    public int SpeedUpDuration
    {
        get { return speedUpDuration;}
    }
    public float SpeedUpFactor
    {
        get { return speedUpFactor;}
    }


    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReading();
    }
    public void StreamReading(){
        StreamReader streamReader = null;      
        //string[] name;
        string[] values;
        try
        {
            streamReader = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string readLine = streamReader.ReadLine();
            readLine.Split(',');
            readLine = streamReader.ReadLine();
            values = readLine.Split(',');
            FillVariablies(values);    
        }
        catch(Exception ){}
        finally
        {
            if(streamReader != null)
            streamReader.Close();
        }
    }
    public void FillVariablies(string[] values){
            paddleMoveUnitsPerSecond = float.Parse(values[0]);
            ballImpulseForce = float.Parse(values[1]);
            ballLifeTime = float.Parse(values[2]);
            minSpawnTime = float.Parse(values[3]);
            maxSpawnTime = float.Parse(values[4]);
            standardBlockPoints = int.Parse(values[5]);
            standardBlockProbability = float.Parse(values[6]);
            bonusBlockPoints = int.Parse(values[7]);
            bonusBlockProbability = float.Parse(values[8]);
            pickUpBlockPoints = int.Parse(values[9]);
            pickUpBlockProbability = float.Parse(values[10]);
            ballLeft = int.Parse(values[11]);
            directionOffset = int.Parse(values[12]);
    }
    #endregion
}
