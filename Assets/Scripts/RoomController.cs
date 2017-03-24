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
    Populate(room, store.smallLight, 4);
    Populate(room, store.blocks[Random.Range(0, store.blocks.Length)], 1);

    if (!room.entryRoom)
    {
      Populate(room, store.tallGirl, 4);
      Populate(room, store.lighthouse, 4);
      Populate(room, store.dronefly, 1);
    }
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
            Vector3 position = GetPositionFromZone(rooms[i], store.key, Random.Range(0, 9));
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
    Vector3 position = GetPositionFromZone(room, store.exit, 4);
    Create(store.exit, position);
  }

  void Populate (Room room, GameObject obj, int roll)
  {
    if (Roll(roll))
    {
      int zone = Random.Range(0, 9);
      if (!room.zones[zone])
      {
        Vector3 position = GetPositionFromZone(room, obj, zone);
        Create(obj, position);
      }
      else
      {
        print("tried to populate zone " + zone);
        print("but it was full!");
      }
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

  Vector3 GetPositionFromZone (Room room, GameObject obj, int zone)
  {
    room.zones[zone] = true;
    switch (zone)
    {
      case 0:
        return new Vector3 (room.xPos + room.roomWidth * 0.25f, obj.transform.position.y, room.zPos + room.roomHeight * 0.75f);
        // break;
      case 1:
        return new Vector3 (room.xPos + room.roomWidth * 0.5f, obj.transform.position.y, room.zPos + room.roomHeight * 0.75f);
        // break;
      case 2:
        return new Vector3 (room.xPos + room.roomWidth * 0.75f, obj.transform.position.y, room.zPos + room.roomHeight * 0.75f);
        // break;
      case 3:
        return new Vector3 (room.xPos + room.roomWidth * 0.25f, obj.transform.position.y, room.zPos + room.roomHeight * 0.5f);
        // break;
      case 4:
        return new Vector3 (room.xPos + room.roomWidth * 0.5f, obj.transform.position.y, room.zPos + room.roomHeight * 0.5f);
        // break;
      case 5:
        return new Vector3 (room.xPos + room.roomWidth * 0.75f, obj.transform.position.y, room.zPos + room.roomHeight * 0.5f);
        // break;
      case 6:
        return new Vector3 (room.xPos + room.roomWidth * 0.25f, obj.transform.position.y, room.zPos + room.roomHeight * 0.25f);
        // break;
      case 7:
        return new Vector3 (room.xPos + room.roomWidth * 0.5f, obj.transform.position.y, room.zPos + room.roomHeight * 0.25f);
        // break;
      case 8:
        return new Vector3 (room.xPos + room.roomWidth * 0.75f, obj.transform.position.y, room.zPos + room.roomHeight * 0.25f);
        // break;
      default:
        print("zone spawn error");
        return Vector3.zero;
    }
  }
}
