// <copyright file="SortType.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.SortAttributes
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// SortType class for performing sorting of csv files on different attributes.
    /// </summary>
    public class SortType
    {
        /// <summary>
        /// Enum Class.
        /// </summary>
        public enum SortBy
        {
            STATE_ASCENDING,
            STATE_CODE_ASCENDING,
            POPULATION_DESCENDING,
            POPULATION_DENSITY_DESCENDING,
            AREA_PER_SQ_KM_DESCENDING,
        }

        /// <summary>
        /// Method for sorting Census List.
        /// </summary>
        /// <param name="list">List of unsorted census data.</param>
        /// <param name="sortType">Enum to know which type of sorting is to be performed.</param>
        /// <returns>Sorted List.</returns>
        public static List<dynamic> SortIndianCensusData(List<dynamic> list, SortBy sortType)
        {
            switch (sortType)
            {
                case SortBy.STATE_ASCENDING: return list.OrderBy(c => c.state).ToList();
                case SortBy.STATE_CODE_ASCENDING: return list.OrderBy(c => c.stateCode).ToList();
                case SortBy.POPULATION_DESCENDING: return list.OrderByDescending(c => c.population).ToList();
                case SortBy.POPULATION_DENSITY_DESCENDING: return list.OrderByDescending(c => c.densityPerSqKm).ToList();
                case SortBy.AREA_PER_SQ_KM_DESCENDING: return list.OrderByDescending(c => c.areaInSqkm).ToList();
                default: return list;
            }
        }
    }
}
