﻿using System;

namespace TestCoreApi.Models.DBView.Northwind
{
    public partial class Sales_Totals_by_Amount
    {
        public decimal? SaleAmount { get; set; }
        public int OrderID { get; set; }
        public string CompanyName { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
