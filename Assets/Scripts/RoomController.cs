using UnityEngine;

public class RoomController : MonoBehaviour
{
  Transform boardHolder;
  Room[] rooms;
  Store store;

  public int lightCount;

  void Start ()
  {
    store = GetComponent<Store>();
  }

  public void Init (Room[] roomArr, GameObject holderObj)
  {
    rooms = roomArr;
    boardHolder = holderObj.transform;

    for (var i = 0; i < rooms.Length; i++)
    {
      PopulateRoom(rooms[i]);
    }
  }

  public void PopulateRoom (Room room)
  {
    PopulateLights(room);
  }

  void PopulateLights (Room room)
  {
    GameObject obj = store.smallLight;
    Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, room.yPos + room.roomHeight / 2, 0);
    Create(obj, position);
  }

  void Create (GameObject obj, Vector3 position)
  {
    GameObject newObj = (GameObject)Instantiate(obj, position, boardHolder.rotation);
    newObj.transform.parent = boardHolder;
  }
}
