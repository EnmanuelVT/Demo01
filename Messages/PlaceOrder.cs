namespace Messages
{
    public class PlaceOrder :
        ICommand
    {
        public string OrderId { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Estado { get; set; }
    }
}
