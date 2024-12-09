namespace SystemSchool.Server.DTO.ClassesDto
{
    public class UpdateCoursesDto
    {
        internal readonly string? Workload;
        internal readonly string? Name;

        public String? Number { get; set; }
        public int Capacity { get; set; }
    }
}
