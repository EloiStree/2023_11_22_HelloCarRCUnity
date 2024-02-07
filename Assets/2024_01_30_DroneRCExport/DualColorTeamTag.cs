using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualColorTeamTag : MonoBehaviour
{
    public ExportDualColorTeamTag m_teamColor = ExportDualColorTeamTag.Other;
}



public enum ExportDualColorTeamTag
{ Other, Red, Blue } 