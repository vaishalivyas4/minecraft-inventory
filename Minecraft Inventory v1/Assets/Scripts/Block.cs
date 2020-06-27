using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public BlockType blockType;
    MeshRenderer mRend;
    BlockProps blockProps;
    int curHits = 0;

    private void Start()
    {
        mRend = GetComponent<MeshRenderer>();
        blockProps = BlockSettings.instance.GetBlockProps(blockType);
        mRend.material = blockProps.normalMat;
    }

    private void OnMouseDown()
    {
        TakeHit();
    }

    void TakeHit()
    {
        curHits++;
        if (curHits<blockProps.maxHits)
        {
            if (curHits>=blockProps.maxHits/2)
            {
                mRend.material = blockProps.damagedMat;
            }
        }
        else
        {
            GameObject go = Instantiate(BlockSettings.instance.pickUp,transform.position,transform.rotation);
            go.GetComponent<ItemPickup>().InitPickup(blockType,blockProps.normalMat);
            Destroy(gameObject);
        }
    }
}
