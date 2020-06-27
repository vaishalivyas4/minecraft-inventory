using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float rotSpeed;

    public float floatStrength;

    public float speed;

    BlockType blockType;

    Vector3 curPos;

    public void InitPickup(BlockType bType, Material mat)
    {
        blockType = bType;
        GetComponent<MeshRenderer>().material = mat;
    }

    private void OnMouseDown()
    {
        Inventory.instance.AddToInventory(blockType);
        Destroy(gameObject);
    }

    void Update()
    {
        curPos = transform.position;
        curPos.y = Mathf.Sin(Time.time*speed)*floatStrength;
        transform.position = curPos;
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);       
    }
}
