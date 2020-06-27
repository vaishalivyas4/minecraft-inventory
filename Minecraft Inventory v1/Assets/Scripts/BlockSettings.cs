using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    Mud,
    Wood,
    Stone
}

public class BlockProps
{
    public int maxHits;
    public Material normalMat, damagedMat;
    public BlockType blockType;
}

public class BlockSettings : MonoBehaviour
{
    public static BlockSettings instance;

    [SerializeField]
    Material[] mats;

    public GameObject pickUp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    public BlockProps GetBlockProps(BlockType bType)
    {
        BlockProps blockProps = new BlockProps();

        switch (bType)
        {
            case BlockType.Mud:
                blockProps.maxHits = 4;
                blockProps.normalMat = mats[0];
                blockProps.damagedMat = mats[1];
                break;
            case BlockType.Wood:
                blockProps.maxHits = 6;
                blockProps.normalMat = mats[2];
                blockProps.damagedMat = mats[3];
                break;
            case BlockType.Stone:
                blockProps.maxHits = 8;
                blockProps.normalMat = mats[4];
                blockProps.damagedMat = mats[5];
                break;
        }

        blockProps.blockType = bType;

        return blockProps;
    }
}
