﻿using UnityEngine;
using System.Collections;

public static class AI_OrangeTeamSettings
{
    public const string TEAM_NAME = "ORANGE"; // Be sure to five your AI a name
    public const string AUTHOR = "";
    public const string VERSION = "0.0";
}


public class AI_Orange : BotAI
{
    // Initialize class variables here


    // This is will most of the AI logic will go
    // It is called once per frame
    void AI_Routine()
    {

        // Example
        BotAI enemy = FindClosestEnemy();
        AI_Orange ally = ( AI_Orange ) FindClosestAlly();

        if ( enemy != null && !ManualControl )
        {
            if ( DistanceToBot( enemy ) > 10f )
            {
                MoveToward( enemy , .6f );

                if ( DistanceToBot( ally ) < 5f )
                {
                    if ( ID %2 == 1 )
                    {
                       MoveRight( .4f );
                    }
                    else
                    {
                        MoveLeft( .4f );
                    }
                }
            }
            else
            {
                MoveToward( enemy , -1f );
            }

            Shoot();
        }
        // End Example
    }



    // DO NOT MODIFY THIS FUNCTION
    new void FixedUpdate()
    {
        if ( Game.GameStart )
        {
            AI_Routine();
            base.FixedUpdate();

            if ( FindEnemies().Length == 0 )
            {
                Game.EndGame( AI_OrangeTeamSettings.TEAM_NAME );
            }
        }
    }
}
