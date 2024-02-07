using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepyTry_ExportMetaInfoToText : MonoBehaviour
{

    public GameDroneTagMono[] m_allDroneInGame;
    public GameDroneTagMono[] m_allDroneInGameBlue;
    public GameDroneTagMono[] m_allDroneInGameRed;

    public GroundedGoldenSnitchTag m_groundSnitch;
    public FlyingGoldenSnitchTag m_flyingSnitch;

    public GameGroundedBallTag m_blueGoal;
    public GameGroundedBallTag m_redGoal;


    public DroneRCShapeMetaInfoMono[] m_droneRcShape;
    public CarRCShapeMetaInfoMono[] m_carRcShape;





    // UPD 65000 bit max 1500 bytes


   // 01010111 0101011 01010101010101010101010101010




    //ms since start|lineinfo|id|position|rotation
    //36005555|pos|-454|3:2:1:|1:1:1:1
    //22h00 00:00:00 1001|pos|ksjf|3:2:1:|1:1:1:1
    //22h00 00:00:00 1001|pos|ksjf|3:2:1:|1:1:1:1
    //||ksjf|3:2:1:|1:1:1:1
    //||ksjf|3:2:1:|1:1:1:1
    //||ksjf|3:2:1:|1:1:1:1
    //||ksjf|3:2:1:|1:1:1:1


    //id|position|rotation
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1

    
    //id|position|rotation
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1
    //ksjf|3:2:1:|1:1:1:1

}


public class TextExport { 

  //  public string [] m_drone
}
