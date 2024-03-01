namespace StreamProgressInfo
{
    public interface IStreamable
    {
        public int Length { get; }
        public int BytesSent { get; }
    }
}
