namespace AMS_DBTC_API_v2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";

        public Course(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
