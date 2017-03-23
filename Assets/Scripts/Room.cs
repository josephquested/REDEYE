using UnityEngine;

public class Room
{
  public int xPos;                      // The x coordinate of the lower left tile of the room.
  public int zPos;                      // The z coordinate of the lower left tile of the room.
  public int roomWidth;                 // How many tiles wide the room is.
  public int roomHeight;                // How many tiles high the room is.
  public Direction enteringCorridor;    // The direction of the corridor that is entering this room.
  public bool entryRoom;                // The room the player enters into
  public bool exitRoom;                // The room with the exit

  public bool[] zones = new bool[9];

  // This is used for the first room.  It does not have a Corridor parameter since there are no corridors yet.
  public void SetupRoom (IntRange widthRange, IntRange heightRange, int columns, int rows)
  {
      // Set a random width and height.
      roomWidth = widthRange.Random;
      roomHeight = heightRange.Random;

      // Set the x and z coordinates so the room is roughly in the middle of the board.
      xPos = Mathf.RoundToInt(columns / 2f - roomWidth / 2f);
      zPos = Mathf.RoundToInt(rows / 2f - roomHeight / 2f);
  }

  // This is an overload of the SetupRoom function and has a corridor parameter that represents the corridor entering the room.
  public void SetupRoom (IntRange widthRange, IntRange heightRange, int columns, int rows, Corridor corridor)
  {
      // Set the entering corridor direction.
      enteringCorridor = corridor.direction;

      // Set random values for width and height.
      roomWidth = widthRange.Random;
      roomHeight = heightRange.Random;

      switch (corridor.direction)
      {
          // If the corridor entering this room is going north...
          case Direction.North:
              // ... the height of the room mustn't go beyond the board so it must be clamped based
              // on the height of the board (rows) and the end of corridor that leads to the room.
              roomHeight = Mathf.Clamp(roomHeight, 1, rows - corridor.EndPositionZ);

              // The z coordinate of the room must be at the end of the corridor (since the corridor leads to the bottom of the room).
              zPos = corridor.EndPositionZ;

              // The x coordinate can be random but the left-most possibility is no further than the width
              // and the right-most possibility is that the end of the corridor is at the position of the room.
              xPos = Random.Range (corridor.EndPositionX - roomWidth + 1, corridor.EndPositionX);

              // This must be clamped to ensure that the room doesn't go off the board.
              xPos = Mathf.Clamp (xPos, 0, columns - roomWidth);
              break;
          case Direction.East:
              roomWidth = Mathf.Clamp(roomWidth, 1, columns - corridor.EndPositionX);
              xPos = corridor.EndPositionX;

              zPos = Random.Range (corridor.EndPositionZ - roomHeight + 1, corridor.EndPositionZ);
              zPos = Mathf.Clamp (zPos, 0, rows - roomHeight);
              break;
          case Direction.South:
              roomHeight = Mathf.Clamp (roomHeight, 1, corridor.EndPositionZ);
              zPos = corridor.EndPositionZ - roomHeight + 1;

              xPos = Random.Range (corridor.EndPositionX - roomWidth + 1, corridor.EndPositionX);
              xPos = Mathf.Clamp (xPos, 0, columns - roomWidth);
              break;
          case Direction.West:
              roomWidth = Mathf.Clamp (roomWidth, 1, corridor.EndPositionX);
              xPos = corridor.EndPositionX - roomWidth + 1;

              zPos = Random.Range (corridor.EndPositionZ - roomHeight + 1, corridor.EndPositionZ);
              zPos = Mathf.Clamp (zPos, 0, rows - roomHeight);
              break;
      }
   }
}
