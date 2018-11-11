﻿using System.Collections;
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
        string[] name;
        string[] values;
        try
        {
            streamReader = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string readLine = streamReader.ReadLine();
            name = readLine.Split(',');
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
    }
    #endregion
}
