namespace StreamProgressInfo
{
    public class StreamProgressInfo
    {
        private IStreamable streamable;

        // If we want to stream a music file, we can't
        //done with adding an interface
        public StreamProgressInfo(IStreamable streamable)
        {
            this.streamable = streamable;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamable.BytesSent * 100) / this.streamable.Length;
        }
    }
}
