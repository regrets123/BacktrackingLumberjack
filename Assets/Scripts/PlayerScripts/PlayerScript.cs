using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*By Björn Andersson*/
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float speed, jumpSpeed, rotateSpeed, gravity, pickUpRange;

    [SerializeField]
    int maxInventory, equippedItemIndex;

    [SerializeField]
    Transform equippedItemPosition;

    Camera mainCam;

    GameObject equippedObject;

    List<GameObject> inventory;

    CharacterController charCont;

    Vector3 moveDirection;

    KeyCode[] equipKeys = new KeyCode[10] { KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9 };

    void Start()
    {
        charCont = GetComponent<CharacterController>();
        mainCam = GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (charCont.isGrounded) //Ser till att man kan röra sig, förutsatt att man står på marken
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))                //Hoppar
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        charCont.Move(moveDirection * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E))            //Kollar om du tittar på något du kan plocka upp och gör i så fall det om du inte har fullt inventory
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.transform.position, Vector3.forward, out hit, pickUpRange))
            {
                if (hit.transform.tag == "PickUpAble")
                {
                    if (inventory.Count < maxInventory)
                    {
                        inventory.Add(hit.transform.gameObject);
                        EquipItem(hit.transform.gameObject, inventory.Count - 1);
                        Destroy(hit.transform.gameObject);
                    }
                    else
                    {
                        //Error message: Inventory is full
                    }
                }
            }
        }
        if (Mathf.RoundToInt(Input.GetAxis("Mouse ScrollWheel")) != 0)  //Byter equippat objekt via scrollhjul
        {
            int newItem = equippedItemIndex + Mathf.RoundToInt(Input.GetAxis("Mouse ScrollWheel"));
            if (newItem >= 0 && newItem < inventory.Count)
            {
                EquipItem(inventory[equippedItemIndex + Mathf.RoundToInt(Input.GetAxis("Mouse ScrollWheel"))], equippedItemIndex + Mathf.RoundToInt(Input.GetAxis("Mouse ScrollWheel")));
            }
        }
        for (int i = 0; i < equipKeys.Length; i++)    //Byter equippat objekt via nummerknappar
        {
            if (Input.GetKeyDown(equipKeys[i]))
            {
                int index;
                if (equipKeys[i] == KeyCode.Alpha0)
                {
                    index = 9;
                }
                else
                {
                    index = i - 1;
                }
                if (index < inventory.Count)
                {
                    EquipItem(inventory[i], index);
                }
            }
        }
    }

    void EquipItem(GameObject item, int index)  //Equippar ett objekt
    {
        if (equippedObject)
        {
            Destroy(equippedObject);
        }
        equippedObject = item;
        equippedItemIndex = index;
        Instantiate(equippedObject, equippedItemPosition);
    }
}