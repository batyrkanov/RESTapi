﻿using RESTapi.Service.Enums;

namespace RESTapi.Service.Query
{
    public class QueryOrder<TOrderType>
    {
        public TOrderType OrderType { get; set; }
        public SortDirectionType Direction { get; set; }
        public int Order { get; set; }
    }
}
