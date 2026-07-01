using System;

public readonly struct CoordenadaGPS
{
    public double Latitud { get; }
    public double Longitud { get; }

    public CoordenadaGPS(double latitud, double longitud)
    {
        if (latitud < -90 || latitud > 90)
            throw new ArgumentOutOfRangeException(nameof(latitud),
                "La latitud debe estar entre -90 y 90.");

        if (longitud < -180 || longitud > 180)
            throw new ArgumentOutOfRangeException(nameof(longitud),
                "La longitud debe estar entre -180 y 180.");

        Latitud = latitud;
        Longitud = longitud;
    }

    public void ImprimirUbicacion()
    {
        Console.WriteLine($"Latitud : {Latitud}");
        Console.WriteLine($"Longitud: {Longitud}");
    }
}