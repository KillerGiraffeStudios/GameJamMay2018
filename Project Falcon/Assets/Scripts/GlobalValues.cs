using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalValues {

    public static int numCreatures = 0;

    private static int _difficulty;
    public static int difficulty
    {
        get
        {
            return _difficulty;
        }

        set
        {
            _difficulty = value;
        }
    }

    private static int _numPlayers;
    public static int numPlayers
    {
        get
        {
            return _numPlayers;
        }

        set
        {
            _numPlayers = value;
        }
    }


    private static int _bearsKilled;
    public static int bearsKilled
    {
        get
        {
            return _bearsKilled;
        }

        set
        {
            _bearsKilled = value;
        }
    }

    private static int _oakTreesKilled;
    public static int oakTreesKilled
    {
        get
        {
            return _oakTreesKilled;
        }

        set
        {
            _oakTreesKilled = value;
        }
    }

    private static int _squirrelsKilled;
    public static int squirrelsKilled
    {
        get
        {
            return _squirrelsKilled;
        }

        set
        {
            _squirrelsKilled = value;
        }
    }

    private static int _rabbitsKilled;
    public static int rabbitsKilled
    {
        get
        {
            return _rabbitsKilled;
        }

        set
        {
            _rabbitsKilled = value;
        }
    }

    private static int _catsKilled;
    public static int catsKilled
    {
        get
        {
            return _catsKilled;
        }

        set
        {
            _catsKilled = value;
        }

    }

    private static int _animalsKilled;
    public static int animalsKilled
    {
        get
        {
            return _catsKilled + _rabbitsKilled + _bearsKilled + _oakTreesKilled + _squirrelsKilled;
        }
    }


	
}
