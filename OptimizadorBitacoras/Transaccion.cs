using System;

struct Transaccion
{
    public int Id;
    public double Monto;
    public long Timestamp;

    public Transaccion(int id, double monto, long timestamp)
    {
        Id = id;
        Monto = monto;
        Timestamp = timestamp;
    }

    public override string ToString()
    {
        return $"ID: {Id,4} | Monto: ${Monto,8:F2} | Timestamp: {Timestamp}";
    }
}