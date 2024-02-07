using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraperLog_ItemComplexShapeMono : AbstractCoroutineScraperLogMono
{

    public FindAndResolveDoubleIdInSceneMono m_itemInGame;
    public float m_refreshListCooldown = 2;
    public bool m_refeshListAtAwake;
    public Dictionary<string, CarRCShapeMetaInfoMono> m_carShape = new Dictionary<string, CarRCShapeMetaInfoMono>();
    public Dictionary<string, DroneRCShapeMetaInfoMono> m_droneShape = new Dictionary<string, DroneRCShapeMetaInfoMono>();

    public void Awake()
    {
        if (m_refeshListAtAwake)
        {
            m_itemInGame.FindAllObjectActiveInScene();
            RefreshPositionInScene();
        }
        InvokeRepeating("RefreshPositionInScene", m_refreshListCooldown, m_refreshListCooldown);
    }

    public override void Push()
    {
        foreach (var id in m_droneShape.Keys)
        {
            DroneRCShapeMetaInfo shapeD = m_droneShape[id].m_shapeInfo;
            GetBroadcaster().Push_ComplexShapeDrone(id,
            shapeD.m_bladeOffsetFrontLeft,
            shapeD.m_bladeOffsetFrontRight,
            shapeD.m_bladeOffsetBackLeft,
            shapeD.m_bladeOffsetBackRight,
            shapeD.m_radiusOfBlade,
            shapeD.m_heightOfBlade,
            shapeD.m_boxColliderOffset,
            shapeD.m_heightOfBoxCollider,
            shapeD.m_widthOfBoxCollider,
            shapeD.m_depthOfBoxCollider
                );
          
        }
        foreach (var id in m_carShape.Keys)
        {
            CarRCShapeMetaInfo shapeC = m_carShape[id].m_shapeInfo;
            GetBroadcaster().Push_ComplexShapeCar(id,
                         shapeC.m_wheelOffsetFrontLeft,
                         shapeC.m_wheelOffsetFrontRight,
                         shapeC.m_wheelOffsetBackLeft,
                         shapeC.m_wheelOffsetBackRight,
                        shapeC.m_radiusOfWheels,
                        shapeC.m_heightOfWheels,
                        shapeC.m_boxCarColliderOffset,
                        shapeC.m_heightOfCarCollider,
                        shapeC.m_widthOfCarCollider,
                        shapeC.m_depthOfCarCollider,
                        shapeC.m_boxCarBodyColliderOffset,
                        shapeC.m_heightOfCarBodyCollider,
                        shapeC.m_widthOfCarBodyCollider,
                        shapeC.m_depthOfCarBodyCollider


                );
        }
    }

    public void RefreshPositionInScene()
    {
        foreach (var item in m_itemInGame.m_shortIdInGame.Values)
        {
            DroneGameItemRootTag tag = FindAndResolveDoubleIdInSceneMono.
                GetComponentInParentOrItself<DroneGameItemRootTag>(item.gameObject);
            if (!tag)
                continue;
            DroneRCShapeMetaInfoMono shapeD = FindAndResolveDoubleIdInSceneMono.
                GetComponentInChildrenOrItself<DroneRCShapeMetaInfoMono>(tag.gameObject);
            if (shapeD)
            {
                if (!m_droneShape.ContainsKey(item.GetShortId()))
                    m_droneShape[item.GetShortId()] = shapeD;
                continue;
            }
            CarRCShapeMetaInfoMono carD = FindAndResolveDoubleIdInSceneMono.
            GetComponentInChildrenOrItself<CarRCShapeMetaInfoMono>(tag.gameObject);

            if (carD)
            {
                if (!m_carShape.ContainsKey(item.GetShortId()))
                    m_carShape[item.GetShortId()] = carD;
                continue;
            }
        }
    }
}
