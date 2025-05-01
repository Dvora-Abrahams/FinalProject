using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Warehouse
{
    public int Id { get; set; }

    public int IdGoods { get; set; }

    public int CurrentStock { get; set; }

    public int MinStock { get; set; }

    public virtual Good IdGoodsNavigation { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
