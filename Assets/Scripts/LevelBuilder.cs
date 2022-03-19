// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// // ================ UNUSED IN THE FINAL PROJECT ================


// public class LevelBuilder : MonoBehaviour
// {
//     [Header("Assets Prefabs")]
//     [SerializeField] GameObject GroundTilePrefab;
//     [SerializeField] GameObject WallsRegularPrefab, WallsDoorPrefab, CeilingTilePrefab;

//     [Header("Other")]
//     [SerializeField] GameObject levelContainer;

//     void Start()
//     {
//         // Build the ground
//         BuildGround();

//         // Build the ceiling
//         BuildCeiling();

//         // Build the walls with the doors
//         BuildWalls();

//         // Build the other pretty stuffs

//         // Build behind the player the door and everything for TheFollower

//     }

//     // ============== [MAP BUILDING METHODS] ================

//     void BuildGround()
//     {
//         Transform GroundTransform = levelContainer.transform.GetChild(0);

//         // Ground Tiles are 8x?x10 slabs of ground.
//         for (int i = 0; i < (int)(GameManager.EndCoordinateValue/10); i++)
//         {
//             // Since it's 10 in z, the first one is centered at 0 so the next one should be centered at 10, next one at 20, etc.
//             Instantiate(GroundTilePrefab, Vector3.forward * i * 10, Quaternion.identity, GroundTransform);
//         }
//     }

//     void BuildWalls()
//     {
//         Transform LeftwallsTransform = levelContainer.transform.GetChild(1);
//         Transform RightwallsTransform = levelContainer.transform.GetChild(2);

//         Quaternion leftRotation = Quaternion.Euler(0, 0, 0);
//         Quaternion rightRotation = Quaternion.Euler(0, 180, 0);

//         Vector3 leftPosition = new Vector3(-4, 5, 0);
//         Vector3 rightPosition = new Vector3(4, 5, 0);

//         // Walls Tiles are 10x10
//         // Left walls tiles
//         for (int i = 0; i < (int)(GameManager.EndCoordinateValue/10); i++)
//         {
//             // Since it's 10 in z, the first one is centered at 0 so the next one should be centered at 10, next one at 20, etc.
//             Instantiate(WallsRegularPrefab, leftPosition + Vector3.forward * i * 10, leftRotation, LeftwallsTransform);
//         }

//         // Walls Tiles are 10x10
//         // Right walls tiles
//         for (int i = 0; i < (int)(GameManager.EndCoordinateValue/10); i++)
//         {
//             // Since it's 10 in z, the first one is centered at 0 so the next one should be centered at 10, next one at 20, etc.
//             Instantiate(WallsRegularPrefab, rightPosition + Vector3.forward * i * 10, rightRotation, RightwallsTransform);
//         }
//     }

//     void BuildCeiling()
//     {
//         Transform CeilingTransform = levelContainer.transform.GetChild(3);

//         Quaternion ceilingRotation = Quaternion.Euler(0, 0, 180);

//         Vector3 ceilingPosition = Vector3.up * 10;

//         // Ground Tiles are 8x?x10 slabs of ground.
//         for (int i = 0; i < (int)(GameManager.EndCoordinateValue/10); i++)
//         {
//             // Since it's 10 in z, the first one is centered at 0 so the next one should be centered at 10, next one at 20, etc.
//             Instantiate(CeilingTilePrefab, Vector3.forward * i * 10 + ceilingPosition, ceilingRotation, CeilingTransform);
//         }
//     }
// }
