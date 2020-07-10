using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private GameObject dropObject;

    public void DropItem()
    {
        dropObject = GetDropObject();
        Vector3 dropVector = new Vector3(Random.Range(transform.position.x - 2f, transform.position.x + 2f), transform.position.y, Random.Range(transform.position.z - 2f, transform.position.z +2f));
        dropObject.transform.position = dropVector;
    }

    private GameObject GetDropObject()
    {
        return Instantiate(Resources.Load<GameObject>("RPG Pack/Prefabs/BoxOfPandora") as GameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(dropObject);
        }
    }
}
