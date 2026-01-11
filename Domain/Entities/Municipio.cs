using System;
using System.Collections.Generic;

namespace SiniestrosVialesOpitech.Domain.Entities;

public partial class Municipio
{
    public int IdMunicipio { get; set; }

    public int CodigoDane { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Siniestro> Siniestros { get; set; } = new List<Siniestro>();
}
