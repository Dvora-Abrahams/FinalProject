using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Sale
{
    public int Id { get; set; }

    public int IdWarehouse { get; set; }

    public int Quantity { get; set; }

    public DateTime SaleDate { get; set; }

    public double TotalPrice { get; set; }

    public virtual Warehouse IdWarehouseNavigation { get; set; } = null!;
}
