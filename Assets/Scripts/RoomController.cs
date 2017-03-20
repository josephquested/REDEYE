using UnityEngine;

public class RoomController : MonoBehaviour
{
  Transform boardHolder;
  Room[] rooms;
  Store store;

  public int lightCount;
  public int locks;
  public int keys = 0;

  void Awake ()
  {
    store = GetComponent<Store>();
  }

  public void Init (Room[] roomArr, GameObject holderObj)
  {
    rooms = roomArr;
    boardHolder = holderObj.transform;

    PopulateKeys();

    for (var i = 0; i < rooms.Length; i++)
    {
      if (rooms[i].exitRoom)
      {
        PopulateExit(rooms[i]);
        return;
      }

      PopulateProps(rooms[i]);
    }
  }

  void PopulateProps (Room room)
  {
    PopulateLights(room);
    PopulateTallGirls(room);
    PopulateLighthouses(room);
  }

  void PopulateKeys ()
  {
    if (keys < locks)
    {
      for (var i = 0; i < rooms.Length; i++)
      {
        if (!rooms[i].exitRoom && !rooms[i].entryRoom)
        {
          if (Roll(4) && keys < locks)
          {
            Vector3 position = new Vector3 (rooms[i].xPos + rooms[i].roomWidth / 2, 1.5f, rooms[i].zPos + rooms[i].roomHeight / 2);
            Create(store.key, position);
            keys += 1;
          }
        }
      }
      PopulateKeys();
    }
  }

  void PopulateExit (Room room)
  {
    Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, 0.1f, room.zPos + room.roomHeight / 2);
    Create(store.exit, position);
  }

  void PopulateLights (Room room)
  {
    if (Roll(3))
    {
      GameObject obj = store.smallLight;
      Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, obj.transform.position.y, room.zPos + room.roomHeight / 2);
      Create(obj, position);
    }
  }

  void PopulateTallGirls (Room room)
  {
    if (Roll(4))
    {
      GameObject obj = store.tallGirl;
      Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, obj.transform.position.y, room.zPos + room.roomHeight / 2);
      Create(obj, position);
    }
  }

  void PopulateLighthouses (Room room)
  {
    if (Roll(4))
    {
      GameObject obj = store.lighthouse;
      Vector3 position = new Vector3 (room.xPos + room.roomWidth / 2, obj.transform.position.y, room.zPos + room.roomHeight / 2);
      Create(obj, position);
    }
  }

  void Create (GameObject obj, Vector3 position)
  {
    GameObject newObj = (GameObject)Instantiate(obj, position, boardHolder.rotation);
    newObj.transform.parent = boardHolder;
  }

  bool Roll (int upperInt)
  {
    return Random.Range(0, upperInt + 1) == 0;
  }
}
