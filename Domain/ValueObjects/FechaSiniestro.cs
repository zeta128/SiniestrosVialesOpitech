using SiniestrosVialesOpitech.Application.Common.Exceptions;
using SiniestrosVialesOpitech.Application.Common.Resources;

namespace SiniestrosVialesOpitech.Domain.ValueObjects
{
    public sealed record FechaSiniestro
    {
        public DateTime Value { get; }

        public FechaSiniestro(DateTime value)
        {
            if (value > DateTime.Now)
                throw new DomainException(MessageKeys.FechaSiniestroNoFutura);

            Value = value;
        }

        public static implicit operator DateTime(FechaSiniestro fecha)
            => fecha.Value;
    }

}
