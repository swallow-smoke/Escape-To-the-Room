namespace Data.Object
{
    public interface IHoldable
    {
        public int weight { get; set; }

        public void OnHold();
    }
}