namespace Commission.Domain.ValueObjects
{
    public class Currency
    {
        public string? Code { get; private set; }

        public Currency(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new ArgumentException(
                "Currency code cannot be null or empty."
            );
            Code = code;
        }
        public override string? ToString() => Code;
    }
}