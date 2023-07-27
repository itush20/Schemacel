﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellFunctions : MonoBehaviour
{
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES
    public static Direction_e[] directionUpdateOrder = { Direction_e.RIGHT, Direction_e.LEFT, Direction_e.UP, Direction_e.DOWN };
    public static List<int> cellUpdateOrder = new List<int>();
    public static Dictionary<int, CellUpdateType_e> cellUpdateTypeDictionary = new Dictionary<int, CellUpdateType_e>();
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES
    //HARD CODED VARIABLES

    //An disctionary defining the specialized ID's used in sorting, for tracked and 
    public static Dictionary<int, int> steppedCellIdDictionary = new Dictionary<int, int>();

    public static int gridWidth = 1;
    public static int gridHeight = 1;
    //Used to check which cell might be at location x, y.
    public static Cell[,] cellGrid;
    //Used to check if x, y is considered a placeable tile.
    public static bool[,] placeableTiles;

    public static LinkedList<Cell> cellList;
    //Cells made during the simulation
    public static LinkedList<Cell> generatedCellList;

    //Cells that need to be updated but not in a specific order.
    //tickedCellList[CellType];
    public static LinkedList<Cell>[] tickedCellList;

    //Cells that need to be updated but in a specific order (Depending on direction).
    //trackedCells[TrackedCell ID][Direction, Distince];
    //public static LinkedList<Cell>[][,] trackedCells;
    // changed to [,][]
    // the jagged array is 2 dimensional
    public static LinkedList<Cell>[,][] trackedCells;

    //trackedCellRotationUpdateQueue[CellType] Cell type must be sorted into a new direction queue if it has been rotated since it was last sorted
    public static LinkedList<Cell>[] trackedCellRotationUpdateQueue;
    //trackedCellPositionUpdateQueue[CellType, Cell Direction] Cell type "X" facing direction "Y" must be sorted before Cells of type X facing direction Y are updated
    public static LinkedList<Cell>[,] trackedCellPositionUpdateQueue;

    public static int GetSteppedCellId(int type) {
        return steppedCellIdDictionary[type];
    }

    public static CellUpdateType_e GetUpdateType(int type) {
        return cellUpdateTypeDictionary[type];
    }
}
