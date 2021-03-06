﻿using System.Diagnostics;

namespace Projekt1.AlgorithmsSearch
{
    public class BinarySearch : IAlgorithm
    {
        private readonly int[] _vector;
        private int _numberToFind;
        private int _arrayLengthToMeassure;
        private int _attempts = 100000000;
        public int OpAssignment;
        public int OpComparisonLt;
        public int OpComparisonEq;
        public int OpIncrement;
        public int OpDecrement;
        public int OpComparisonSte;

        public BinarySearch(int[] vector)
        {
            _vector = vector;
            _arrayLengthToMeassure = vector.Length;
        }

        public BinarySearch(int[] vector, int numberToFind)
        {
            _vector = vector;
            _numberToFind = numberToFind;
            _arrayLengthToMeassure = vector.Length;
        }

        public int AlgorithmInstrumentation()
        {
            int left = 0;
            int right = _arrayLengthToMeassure - 1;
            OpAssignment = OpComparisonLt = 1;
            OpIncrement = OpDecrement = OpComparisonEq = OpComparisonSte =0;

            OpComparisonSte++;
            while(left <= right)
            {
                OpAssignment++;
                int middle = (left + right) >> 1;

                OpComparisonEq++;
                if (_vector[middle] == _numberToFind)
                    return middle;

                OpComparisonLt++;
                if (_vector[middle] > _numberToFind)
                {
                    OpDecrement++;
                    OpAssignment++;
                    right = middle - 1;
                }
                else
                {
                    OpIncrement++;
                    OpAssignment++;
                    left = middle + 1;
                }
            }

            return -1;
        }

        public double AlgorithmSpeedTest()
        {
            long startTime = Stopwatch.GetTimestamp();

            for(var i = 0; i < _attempts; i++)
                BinarySearchAlgorithm();

            long stopTime = Stopwatch.GetTimestamp();

            return (stopTime - startTime) / (double)Stopwatch.Frequency;
        }

        public int BinarySearchAlgorithm()
        {
            int left = 0;
            int right = _arrayLengthToMeassure - 1;

            while(left <= right)
            {
                int middle = (left + right) >> 1;

                if (_vector[middle] == _numberToFind)
                    return middle;
                if (_vector[middle] > _numberToFind)
                    right = middle - 1;
                else
                    left = middle + 1;
            }

            return -1;
        }

        public void SetAttempts(int limit)
        {
            _attempts = limit;
        }

        public void SetLimitArrayToCheck(int limit)
        {
            _arrayLengthToMeassure = limit < _vector.Length ? limit : _vector.Length;
        }

        public void SetNumberToFind(int numberToFind)
        {
            _numberToFind = numberToFind;
        }

        public string GetInstrumentation()
        {
            return $"{OpAssignment}; {OpComparisonEq}; {OpComparisonLt}; {OpComparisonSte}; {OpIncrement}; {OpDecrement}";
        }
    }
}