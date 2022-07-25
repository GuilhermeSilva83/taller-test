using System.Collections.Generic;

namespace TallerTest.WebApi.Dto
{
    public class MakeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarDto> Cars { get; set; }
    }
}
