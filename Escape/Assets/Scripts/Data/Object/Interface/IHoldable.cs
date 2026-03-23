namespace Data.Object.Interface
{
    public interface IHoldable
    {
        public int weight { get; set; }

        public void OnHold();
    }
}