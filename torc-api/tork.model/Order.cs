﻿namespace torc.model;
public class Order
{
    public int Id { get; set; }
    public int ProductId { get; set; }

    public int CustomerId { get; set; }
    public int Quantity { get; set;  }
    public decimal Cost { get; set; }
}

