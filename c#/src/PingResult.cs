namespace OSPing
{
    struct PingResult
    {
        public int World { get; set; }
        public long Ping { get; set; }

        public PingResult(int World, long Ping)
            : this()
        {
            this.World = World;
            this.Ping = Ping;
        }
    }
}
