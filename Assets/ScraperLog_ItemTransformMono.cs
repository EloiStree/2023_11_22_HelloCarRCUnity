using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraperLog_ItemTransformMono : AbstractCoroutineScraperLogMono
{

    public Transform m_gameCenterRoot;
    public FindAndResolveDoubleIdInSceneMono m_itemInGame;
    public bool m_useEuler;

    public float m_refreshListCooldown=2;
    public bool m_refeshListAtAwake;
    public Dictionary<string, PositionRotationOfDroneGameItemMono> m_tempMemory = new Dictionary<string, PositionRotationOfDroneGameItemMono>();

    public void Awake()
    {
        if (m_refeshListAtAwake) {
            m_itemInGame.FindAllObjectActiveInScene();
            RefreshPositionInScene();
        }
        InvokeRepeating("RefreshPositionInScene", m_refreshListCooldown, m_refreshListCooldown);
    }

    public override void Push()
    {
        foreach (var id in m_tempMemory.Keys)
        {
            GetBroadcaster().Push_ItemPositionRotation(id, m_gameCenterRoot, m_tempMemory[id].GetTransform(), m_useEuler);
        }
    }

    public void RefreshPositionInScene() {
        foreach (var item in m_itemInGame.m_shortIdInGame.Values)
        {
            DroneGameItemRootTag tag = FindAndResolveDoubleIdInSceneMono.
                GetComponentInParentOrItself<DroneGameItemRootTag>(item.gameObject);
            if (!tag)
                continue;
            PositionRotationOfDroneGameItemMono position = FindAndResolveDoubleIdInSceneMono.
                GetComponentInChildrenOrItself<PositionRotationOfDroneGameItemMono>(tag.gameObject);
            if (!position)
                continue;
            if (!m_tempMemory.ContainsKey(item.GetShortId()))
                m_tempMemory[item.GetShortId()] = position;
        }
    }
}
