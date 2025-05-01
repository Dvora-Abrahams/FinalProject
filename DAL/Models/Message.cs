using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Message
{
    public int Id { get; set; }

    public int SupplierId { get; set; }

    public bool IsFromSupplier { get; set; }

    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public bool IsRead { get; set; }

    public int StoreId { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;
}
