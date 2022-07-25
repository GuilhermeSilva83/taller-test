namespace TallerTest.WebApi.Dto
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Color { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }
        public short Year { get; set; }
        public short Doors { get; set; }
        public decimal Price { get; set; }

        public MakeDto Make { get; set; }
    }
}
