namespace DataCore.Models;

/// <summary>
/// Representa un registro de datos inmutable.
/// </summary>
public readonly struct RegistroDatos : IEquatable<RegistroDatos>
{
    /// <summary>
    /// Identificador único del registro.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Valor numérico asociado al registro.
    /// </summary>
    public double Valor { get; }

    /// <summary>
    /// Etiqueta descriptiva del registro.
    /// </summary>
    public string Etiqueta { get; }

    /// <summary>
/// Inicializa una nueva instancia de RegistroDatos.
/// </summary>
/// <param name="id">Identificador del registro.</param>
/// <param name="valor">Valor numérico.</param>
/// <param name="etiqueta">Etiqueta descriptiva.</param>
public RegistroDatos(int id, double valor, string etiqueta)
{
    if (string.IsNullOrWhiteSpace(etiqueta))
    {
        throw new ArgumentException(
            "La etiqueta no puede estar vacía.",
            nameof(etiqueta));
    }

    Id = id;
    Valor = valor;
    Etiqueta = etiqueta;
}
/// <summary>
/// Determina si el registro actual es igual a otro registro.
/// </summary>
/// <param name="other">Registro que se comparará.</param>
/// <returns>
/// true si ambos registros tienen el mismo Id, Valor y Etiqueta;
/// de lo contrario, false.
/// </returns>
public bool Equals(RegistroDatos other)
{
    return Id == other.Id
        && Valor.Equals(other.Valor)
        && Etiqueta == other.Etiqueta;
}

/// <inheritdoc />
public override bool Equals(object? obj)
{
    return obj is RegistroDatos other &&
           Equals(other);
}

/// <inheritdoc />
public override int GetHashCode()
{
    return HashCode.Combine(Id, Valor, Etiqueta);
}

/// <summary>
/// Determina si dos registros son iguales.
/// </summary>
public static bool operator ==(
    RegistroDatos izquierdo,
    RegistroDatos derecho)
{
    return izquierdo.Equals(derecho);
}

/// <summary>
/// Determina si dos registros son diferentes.
/// </summary>
public static bool operator !=(
    RegistroDatos izquierdo,
    RegistroDatos derecho)
{
    return !izquierdo.Equals(derecho);
}

/// <summary>
/// Devuelve una representación legible del registro.
/// </summary>
/// <returns>
/// Cadena con el identificador, valor y etiqueta del registro.
/// </returns>
public override string ToString()
{
    return $"ID: {Id,3} | Valor: {Valor,10:F2} | Etiqueta: {Etiqueta}";
}
}