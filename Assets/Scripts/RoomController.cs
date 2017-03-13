using UnityEngine;

public class RoomController : MonoBehaviour
{
  Transform boardHolder;
  Room[] rooms;
  Store store;

  public int lightCount;
  public int locks;

  void Awake ()
  {
    store = GetComponent<Store>();
  }

  public void Init (Room[] roomArr, GameObject holderObj)
  {
    rooms = roomArr;
    boardHolder = holderObj.transform;

    for (var i = 0; i < rooms.Length; i++)
    {
      if (rooms[i].exitRoom)
      {
        PopulateExit(rooms[i]);
        return;
      }

      PopulateRoom(rooms[i]);
    }
  }

  public void PopulateRoom (Room room)
  {
    PopulateLights(room);
    PopulateTallGirls(room);
  }

  public void PopulateExit (Room room)
  {
    Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, 0.1f, room.zPos + room.roomHeight / 2);
    Create(store.exit, position);
  }

  void PopulateLights (Room room)
  {
    if (Random.Range(0, 3) == 0)
    {
      GameObject obj = store.smallLight;
      Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, obj.transform.position.y, room.zPos + room.roomHeight / 2);
      Create(obj, position);
    }
  }

  void PopulateTallGirls (Room room)
  {
    if (Random.Range(0, 4) == 0)
    {
      GameObject obj = store.tallGirl;
      Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, obj.transform.position.y, room.zPos + room.roomHeight / 2);
      Create(obj, position);
    }
  }

  void Create (GameObject obj, Vector3 position)
  {
    GameObject newObj = (GameObject)Instantiate(obj, position, boardHolder.rotation);
    newObj.transform.parent = boardHolder;
  }
}
